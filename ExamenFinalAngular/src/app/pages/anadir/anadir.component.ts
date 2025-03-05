import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { ObjetoService } from 'src/app/service/objeto.service';
import { CreateObjetoModel } from 'src/app/models/CreateObjetoModel';

@Component({
  selector: 'app-anadir',
  standalone: true,
  imports: [FormsModule], 
  templateUrl: './anadir.component.html',
  styleUrls: ['./anadir.component.css']
})
export class AnadirComponent { 
  nuevoObjeto: CreateObjetoModel = {
    dni_Creador: '',
    dni_Prof_Asociado: '',
    nombre: '',
    descripcion: '',
    iD_Departamento: 0,
    fecha_Presentacion: new Date(),
    aula_Presentacion: '',
    status:'new',
    fecha:new Date()
  };
  

  constructor(private objetoService: ObjetoService) {} 

  async crearObjeto() {
    if (
      !this.nuevoObjeto.dni_Creador.trim() ||
      !this.nuevoObjeto.dni_Prof_Asociado.trim() ||
      !this.nuevoObjeto.nombre.trim() ||
      !this.nuevoObjeto.descripcion.trim() ||
      !this.nuevoObjeto.aula_Presentacion.trim()
    ) {
      alert('Todos los campos son obligatorios.');
      return;
    }
    

    try {
      const resultado = await this.objetoService.createProduct(this.nuevoObjeto);
      if (resultado) {
        console.log('Producto creado:', resultado);
        alert('Producto creado exitosamente');
      } else {
        alert('Error al crear el producto.');
      }
    } catch (error) {
      console.error('Error al crear el producto:', error);
      alert('Error al conectar con el servidor.');
    }
  }

  goBack() {
    window.history.back();
  }
}
