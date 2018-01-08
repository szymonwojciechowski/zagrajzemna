import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  title = 'Zagraj ze mną';
  col2 = 'Dowiedz się więcej';
  col3 = 'Warto zobaczyć';
  newsletter = 'Bądź na bieąco';
  newsletterSignIn = 'Zapisz się do newslettera';
}
