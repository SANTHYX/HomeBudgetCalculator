import {animate, group, query, style, transition, trigger} from '@angular/animations';

function slideTo(dir: string) {
  const optional = {optional: true}
  return [
    query(':enter, :leave', [
      style({
        position: 'absolute',
        top: 0,
        [dir]: 0,
        width: '100%'
      })
    ], optional),
    query(':enter', [
      style({[dir]: '-100%'})
    ]),
    group([
      query(':leave', [
        animate('600ms ease', style({[dir]: '100%'}))
      ], optional),
      query(':enter', [
        animate('600ms ease', style({[dir]: '0%'}))
      ])
    ]),
  ];
}

export const fader =
  trigger('routeAnimations', [
    transition('* => isLeft', slideTo('left')),
    transition('* => isRight', slideTo('right')),
    transition('isRight => *', slideTo('left')),
    transition('isLeft => *', slideTo('right'))
  ]);
