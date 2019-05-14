import { Pipe, PipeTransform } from '@angular/core';
import {CommonModule} from "@angular/common";
@Pipe({
  name: 'searching'
})
export class SearchingPipe implements PipeTransform {
  transform(items: any[], searchText: string): any[] {
    if(!items) return [];
    if(!searchText) return items;

    searchText = searchText.toLowerCase();
    return items.filter( it => {
      return it.title.toLowerCase().includes(searchText);
    });
  }
}
