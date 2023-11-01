import paperClasses from './app/pages/Paper/PaperClass/reducer';
import paperSizes from './app/pages/Paper/PaperSize/reducer';
import paperDensities from './app/pages/Paper/PaperDensity/reducer';
import papers from './app/pages/Paper/Paper/reducer';
import paperCoefficients from './app/pages/Paper/PaperCoefficient/reducer';
import paperFormats from './app/pages/Paper/PaperFormat/reducer';
import paperPriceGroups from './app/pages/Paper/PaperPriceGroup/reducer';
import paperTypes from './app/pages/Paper/PaperType/reducer';

import packagingTypes from './app/pages/PostPrint/PackagingType/reducer';
import postPrintGroups from './app/pages/PostPrint/PostPrintGroup/reducer';
import postPrintOperations from './app/pages/PostPrint/PostPrintOperation/reducer';
import postPrintPrices from './app/pages/PostPrint/PostPrintPrice/reducer';
import postPrintPriceGroups from './app/pages/PostPrint/PostPrintPriceGroup/reducer';
import postPrintTargets from './app/pages/PostPrint/PostPrintTarget/reducer';

import categories from './app/pages/Storage/Category/reducer';
import storages from './app/pages/Storage/Storage/reducer';
import storageProducts from './app/pages/Storage/StorageProduct/reducer';
import subCategories from './app/pages/Storage/SubCategory/reducer';
import unitMeasures from './app/pages/Storage/UnitMeasure/reducer';

import options from './app/pages/TechProcess/Option/reducer';
import printTypes from './app/pages/TechProcess/PrintType/reducer';
import sectors from './app/pages/TechProcess/Sector/reducer';
import techProcesses from './app/pages/TechProcess/TechProcess/reducer';
import techProcessOptions from './app/pages/TechProcess/TechProcessOption/reducer';

import authorization from './app/service/authorization/reducer';
import dialog from './app/service/dialog/reducer';
import notifications from './app/service/notifications/reducer';

const lastAction = (state = null, action) => {
    return action;
}



export { authorization }
export { dialog }
export { notifications }

export { paperClasses }
export { paperSizes }
export { paperDensities }
export { papers }
export { paperCoefficients }
export { paperFormats }
export { paperPriceGroups }
export { paperTypes }

export { packagingTypes }
export { postPrintGroups }
export { postPrintOperations }
export { postPrintPrices }
export { postPrintPriceGroups }
export { postPrintTargets }

export { categories }
export { storages }
export { storageProducts }
export { subCategories }
export { unitMeasures }

export { options }
export { printTypes }
export { sectors }
export { techProcesses }
export { techProcessOptions }

export { lastAction }