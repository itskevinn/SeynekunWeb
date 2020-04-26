import { Pipe, PipeTransform } from '@angular/core';
import { Empleado } from 'src/app/seynekun/models/modelo-empleado/empleado';

@Pipe({
  name: 'filtroEmpleado'
})
export class FiltroEmpleadoPipe implements PipeTransform {

  transform(empleados: Empleado[], textoABuscar: string): any {
    if (textoABuscar == null) return empleados;
    return empleados.filter(e => e.nombre.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.apellido.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.cedula.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1
      || e.estado.toLowerCase().indexOf(textoABuscar.toLowerCase()) !== -1);      
  }
}
