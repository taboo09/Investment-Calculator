import { NotificationType } from ".";

export interface Message{
    MessageInfo: string;
    ErrorStatus?: number;
    Notification: NotificationType;
}

