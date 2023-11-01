
export const utils = {
	form: {
		fromJson: (data) => {
			let formData = new FormData();

			for (var key in data)
				if (data[key]) {
					let value = data[key];
					//formData.append(key, value);
					utils.form.addProp(formData, key, value, []);
				}

			return formData;
		},
		addProp: (data, key, value, prefixes) => {
			if (
				typeof value === 'object' &&
				!Array.isArray(value) &&
				!(value instanceof File)
			) {
				for (var subKey in value)
					if (value[subKey]) {
						let subValue = value[subKey];
						utils.form.addProp(data, key, subValue, [...prefixes, subKey]);
					}
			} else if (Array.isArray(value)) {
				for (var i = 0; i < value.length; i++) {
					utils.form.addProp(data, key, value[i], [...prefixes, '[' + i + ']']);
					//data.append([key, ...prefixes].join('') + '[' + i + ']', JSON.stringify(value[i]));
                }
			} else {
				//data.append(key + prefixes.map(x => '[' + x + ']').join(''), value);
				let kvx = key;
				if (prefixes.length > 0) {
					kvx = prefixes.reduce((r, c) => {
						if (c.startsWith('[') && c.endsWith(']'))
							return r + c;
						else
							return r + '.' + c;
					}, kvx);
				}
				if (typeof value == 'number')
					value = value.toString().replace('.', ',');
				data.append(kvx, value);
			}
        },
    },
	array: {
		distinctBy: (input, predicate) => {
			let result = [];
			let keys = [];
			for (let i = 0; i < input.length; i++) {
				let key = predicate(input[i]);
				if (keys.includes(key))
					continue;
				keys.push(key);
				result.push(input[i]);
			}
			return result;
		},
		includesAll: (input, includes) => {
			input = input || [];
			includes = includes || [];
			return includes.every(i => input.includes(i));
        },
	},
	int: {
		clamp: (input, min, max) => {
			if (input < min)
				return min;
			if (input > max)
				return max;
			return input;
        },
	},
	date: {
		split: (date) => {
			if (!date)
				return null;

			let segs = date.split('.');
			let day = segs[0];
			let month = segs[1];
			let year = segs[2];

			if (day.toString().length == 1)
				day = '0' + day;
			if (month.toString().length == 1)
				month = '0' + month;

			return ({
				day: day,
				month: month,
				year: year,
			});
		},
		combine: (state) => {
			if (!state)
				return null;

			let day = state.day;
			let month = state.month;
			let year = state.year;

			if (day.toString().length == 1)
				day = '0' + day;
			if (month.toString().length == 1)
				month = '0' + month;

			return day + '.' + month + '.' + year;
		},
	},
	color: {
		rainbow: (count, saturation, lightness) => {
			let result = [...Array(count).keys()];
			let step = 360 / count;
			result = result.map(x => Math.round(x * step));
			if (!saturation)
				saturation = '100%';
			if (!lightness)
				lightness = '50%';
			result = result.map(x => 'hsl(' + x + ' ' + saturation + ' ' + lightness + ')');
			return result;
        },
	},
	
};