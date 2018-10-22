import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { SessionProvider } from '../providers/session/session';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(public auth: SessionProvider) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    const header = this.auth.getToken()? {
      Authorization: `Bearer ${this.auth.getToken()}`,
     
    } : {
    };
    
    // if(!header['Content-Type']){
    //   header['Content-Type'] =  'application/json';
    // }

     request = request.clone({
       setHeaders:header
     });
    return next.handle(request);
  }
} 