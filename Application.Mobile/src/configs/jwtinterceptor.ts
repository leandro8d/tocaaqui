// src/app/auth/jwt.interceptor.ts
// ...
import 'rxjs/add/operator/do';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor,
    HttpResponse,
    HttpErrorResponse
} from '@angular/common/http';
import { LoginPage } from '../pages/login/login';
import {App} from "ionic-angular";
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';


@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(public app:App) {
        
    }


    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        return next.handle(request).do((event: HttpEvent<any>) => {
            if (event instanceof HttpResponse) {
                // do stuff with response if you want
            }
        }, (err: any) => {
            if (err instanceof HttpErrorResponse) {
                if (err.status === 401) {
                    let nav = this.app.getActiveNav();
                    nav.push(LoginPage);
                }
            }
        });
    }
}