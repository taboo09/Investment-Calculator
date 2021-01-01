import { InterestSchedule } from "./InterestSchedule";

export class ResponseBase{
    EndBalance!: number;
    StartPrincipal!: number;
    TotalContribution!: number;
    TotalInterest!: number;
    InterestSchedule: InterestSchedule[] = [];
}