import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = window.location.origin + '/odata/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable()
export class RestService {
  constructor(private http: HttpClient) {

  }

  updateSatisfaction(employeeId, satisfactionScore): Observable<any> {
    return this.http.patch(endpoint + "/Employees(" + employeeId + ")", { SatisfactionScore: satisfactionScore });
  }

  getEmployees(): Observable<any> {
    return this.http.get(endpoint + "/EmployeesWithSalary").pipe(map(this.extractData));
  }

  private extractData(res: Response) {
    let body = res;
    return (body as any).value || [];
  }
}
