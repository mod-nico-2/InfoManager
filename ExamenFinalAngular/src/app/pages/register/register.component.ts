import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/Auth.service';
import { RegistroDTO } from '../../models/registroDTO';
import { CreateAlumnoDTO } from '../../models/createAlumno';
import { CreateProfesorDTO } from '../../models/createProfesor';
import { firstValueFrom } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class RegisterComponent {
  username: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  tipoUsuario: string = '';

  dni!: number;
  apellido: string = '';

  curso: string = '';

  idDepartamento!: number;

  constructor(private authService: AuthService, private router: Router) {}

  async register() {
    // Validación de campos generales
    if (!this.username || !this.email || !this.password || !this.confirmPassword || !this.tipoUsuario) {
      alert('Todos los campos generales son obligatorios.');
      return;
    }

    if (this.password !== this.confirmPassword) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    // Crea el objeto de registro de usuario
    const registroDto: RegistroDTO = {
      name: this.username,
      userName: this.username,
      email: this.email,
      password: this.password,
      role: this.tipoUsuario
    };

    try {
      // Primero registra el usuario
      await firstValueFrom(this.authService.register(registroDto));

      // Según el tipo de usuario, envía los datos adicionales
      if (this.tipoUsuario === 'alumno') {
        // Validar campos específicos para alumno
        if (!this.dni || !this.apellido || !this.curso) {
          alert('Complete todos los datos del alumno.');
          return;
        }
        const alumnoDto: CreateAlumnoDTO = {
          DNI: this.dni,
          Nombre: this.username, // Se utiliza el nombre de usuario, o se puede tener un campo adicional "nombre"
          Apellido: this.apellido,
          Curso: this.curso,
          Prof_Asociado: '' // Puedes asignar un valor o dejarlo vacío si es opcional
        };
        await firstValueFrom(this.authService.createAlumno(alumnoDto));
      } else if (this.tipoUsuario === 'profesor') {
        // Validar campos específicos para profesor
        if (!this.dni || !this.apellido || !this.idDepartamento) {
          alert('Complete todos los datos del profesor.');
          return;
        }
        const profesorDto: CreateProfesorDTO = {
          DNI: this.dni,
          Nombre: this.username,
          Apellido: this.apellido,
          ID_Departamento: this.idDepartamento
        };
        await firstValueFrom(this.authService.createProfesor(profesorDto));
      }

      alert('Usuario registrado con éxito');
      this.router.navigate(['/']);
    } catch (error: any) {
      alert(error.message);
    }
  }

  goToLogin() {
    this.router.navigate(['/']);
  }
}
