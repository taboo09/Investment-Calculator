import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Message } from '../models';

@Injectable()
export class MessageService {

  private MessageSubject: BehaviorSubject<Message> = new BehaviorSubject<Message>(undefined as unknown as Message);

  public MessageObs: Observable<Message> = this.MessageSubject.asObservable();

  constructor() { }

  displayMessage(m: Message){
    this.MessageSubject.next(m);
  }

}
