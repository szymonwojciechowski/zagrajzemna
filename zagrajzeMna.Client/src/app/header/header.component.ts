import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  title = 'Zagraj ze mną';
  login = 'Zaloguj się';
  register = 'Zarejestruj się';
}
