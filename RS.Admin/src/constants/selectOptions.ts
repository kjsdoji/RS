import ISelectOption from "src/interfaces/ISelectOption";
import { 
    NormalBrandType, 
    LuxuryBrandType,
    AllBrandType,
    NormalBrandTypeLabel,
    LuxyryBrandTypeLabel,
    AllBrandTypeLabel
} from "src/constants/Brand/BrandConstants";

export const BrandTypeOptions: ISelectOption[] = [
    { id: 1, label: NormalBrandTypeLabel, value: NormalBrandType },
    { id: 2, label: LuxyryBrandTypeLabel, value: LuxuryBrandType },
];

export const FilterBrandTypeOptions: ISelectOption[] = [
    { id: 1, label: AllBrandTypeLabel, value: AllBrandType },
    { id: 2, label: NormalBrandTypeLabel, value: NormalBrandType },
    { id: 3, label: LuxyryBrandTypeLabel, value: LuxuryBrandType },
];
