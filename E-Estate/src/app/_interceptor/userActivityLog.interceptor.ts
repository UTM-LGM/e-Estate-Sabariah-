import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserActivityLog } from "../_model/userActivityLog";
import { UserActivityLogService } from "../_services/user-activity-log.service";


@Injectable()
    export class UserActivityLogInterceptor implements HttpInterceptor {
    userActivity={}as UserActivityLog
  
  constructor(private userActivityLogService: UserActivityLogService) {}
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (req.method === 'PUT' || req.method === 'DELETE') {
      
      this.userActivity.dateTime = new Date();
      this.userActivity.method = req.method;
      this.userActivity.body = JSON.stringify(req.body);
      this.userActivity.url = req.url;

      this.userActivityLogService.logActivity(this.userActivity)
      .subscribe(
        Response => {},
        Error => {
          console.error('Error logging user activity:', Error);
        }
      );
      return next.handle(req);
    } else {
      return next.handle(req);
    }
      }
}