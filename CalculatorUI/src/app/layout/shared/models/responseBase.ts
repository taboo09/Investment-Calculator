import { InterestSchedule } from "./InterestSchedule";

export class ResponseBase{
    endBalance!: number;
    startPrincipal!: number;
    totalContribution!: number;
    totalInterest!: number;
    inflationAdjustment!: number;
    totalTax!: number;
    interestSchedule: InterestSchedule[] = [];
}