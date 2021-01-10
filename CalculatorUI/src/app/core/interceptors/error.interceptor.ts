import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Message, NotificationType } from 'src/app/shared/models';
import { MessageService } from 'src/app/shared/services/message.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private messageService: MessageService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError((error: HttpErrorResponse) => {
        let messageError: Message;

        if (error.error instanceof ErrorEvent) {
            messageError = {
              MessageInfo: error.error.message.toString(),
              ErrorStatus: 1,
              Notification: NotificationType.Error
            };

        } else {
            messageError = {
              MessageInfo: error.status === 0 ? 'server error' : error.error.toString(),
              ErrorStatus: error.status,
              Notification: NotificationType.Error
            };
        }

        this.messageService.displayMessage(messageError);

        return throwError(messageError);
      }
    ));
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};