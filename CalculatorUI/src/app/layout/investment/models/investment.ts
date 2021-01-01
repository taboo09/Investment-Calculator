import { RequestBase } from "src/app/layout/shared/models";
import { Period } from "./period";

export class Investment extends RequestBase {
    PeriodInvestment: Period = 0;
}
