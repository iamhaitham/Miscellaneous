import { Injectable } from '@angular/core';
import { AllowedSpecialCharacter } from '../helpers';

@Injectable()
export class TypingSpeedTestSerice {
  getKeysToRecord(keydown: KeyboardEvent): boolean {
    const isEnglishLetter = !!keydown.code.match(/Key[A-Z]/g);
    const isAnAllowedSpecialCharacter: boolean = Object.keys(AllowedSpecialCharacter).includes(keydown.code);

    return isEnglishLetter || isAnAllowedSpecialCharacter;
  }
}