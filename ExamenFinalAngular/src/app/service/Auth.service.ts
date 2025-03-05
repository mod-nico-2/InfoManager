import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginDTO } from '../models/loginDTO';
import { RegistroDTO } from '../models/registroDTO';
import { CreateAlumnoDTO } from '../models/createAlumno';
import { CreateProfesorDTO } from '../models/createProfesor';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  readonly baseUrl = 'https://localhost:8081/api/users';
  private loginUrl = `${this.baseUrl}/login`;
  private registerUrl = `${this.baseUrl}/register`;
  private token: string | null = null;
  private alumnoUrl = 'https://localhost:8081/api/Alumno';
  private profesorUrl = 'https://localhost:8081/api/Profesor';
  constructor() {
    // Recuperar el token desde localStorage al inicializar el servicio
    this.token = localStorage.getItem('authToken');
  }

  login(credentials: LoginDTO): Observable<any> {
    return new Observable<any>(observer => {
      fetch(this.loginUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(credentials)
      })
      .then(response => response.json())
      .then(data => {
        console.log('Login response:', data);
        if (data?.result?.token) {
          this.setToken(data.result.token);
        } else {
          console.warn('⚠️ No se recibió un token válido:', data);
        }
        observer.next(data); // 🔥 Asegura que el Observable emita un valor
        observer.complete(); // 🛑 Finaliza el Observable
      })
      .catch(error => {
        observer.error(error);
      });
    });
  }  

  register(registroDto: RegistroDTO): Observable<any> {
    return new Observable<any>(observer => {
      fetch(this.registerUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(registroDto)
      })
      .then(async response => {
        const data = await response.json();
        console.log('Registro - Respuesta de la API:', data); 
  
        if (response.ok) {
          observer.next(data);
          observer.complete();
        } else {
          console.log(response);
          observer.error(new Error(data?.message || 'Erroren el registro, compruebe los campos'));
        }
      })
      .catch(error => observer.error(error));
    });
  }
  
  setToken(token: string): void {
    this.token = token;
    localStorage.setItem('authToken', token);
  }

  getToken(): string | null {
    return this.token || localStorage.getItem('authToken');
  }

  logout(): void {
    this.token = null;
    localStorage.removeItem('authToken');
  }
  createAlumno(alumnoDto: CreateAlumnoDTO): Observable<any> {
    return new Observable<any>(observer => {
      fetch(this.alumnoUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(alumnoDto)
      })
      .then(async response => {
        const data = await response.json();
        console.log('Respuesta creación alumno:', data);
        if (response.ok) {
          observer.next(data);
          observer.complete();
        } else {
          observer.error(new Error(data?.message || 'Error al crear alumno'));
        }
      })
      .catch(error => observer.error(error));
    });
  }
  
  createProfesor(profesorDto: CreateProfesorDTO): Observable<any> {
    return new Observable<any>(observer => {
      fetch(this.profesorUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(profesorDto)
      })
      .then(async response => {
        const data = await response.json();
        console.log('Respuesta creación profesor:', data);
        if (response.ok) {
          observer.next(data);
          observer.complete();
        } else {
          observer.error(new Error(data?.message || 'Error al crear profesor'));
        }
      })
      .catch(error => observer.error(error));
    });
  }
}