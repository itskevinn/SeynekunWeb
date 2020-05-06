import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtroBodega'
})
export class FiltroBodegaPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
