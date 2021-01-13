import { CompoundPeriod, InterestPeriod } from ".";
import { RequestBase } from "../../shared/models";

export class InterestModel extends RequestBase {
    InflationRate!: number;
    TaxRate!: number;
    InterestPeriod: InterestPeriod = 0;
    CompoundPeriod: CompoundPeriod = 0;
}