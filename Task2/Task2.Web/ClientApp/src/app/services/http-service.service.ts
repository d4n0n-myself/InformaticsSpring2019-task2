import { Injectable, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {}
}
