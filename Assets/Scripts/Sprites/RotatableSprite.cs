using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alf.Utils;


public class RotatableSprite
{
    private Rotation _rotationCW;
    private Sprite[] _sprite;

    public Sprite Sprite
    {
        get
        {
            if(_sprite.Length < (int) _rotationCW)
                return _sprite[_sprite.Length - 1];
            
            return _sprite[(int) _rotationCW];
        }
    }

    public RotatableSprite(Sprite[] sprite)
    {
        _sprite = sprite;
        _rotationCW = Rotation.ZERO;
    }

    public Sprite Next()
    {
        switch (_rotationCW)
        {
            case Rotation.ZERO:
                _rotationCW = Rotation.NINETY_CW;
                break;
            case Rotation.NINETY_CW:
                _rotationCW = Rotation.ONE_EIGHTY;
                break;
            case Rotation.ONE_EIGHTY:
                _rotationCW = Rotation.NINETY_CCW;
                break;
            case Rotation.NINETY_CCW:
                _rotationCW = Rotation.ZERO;
                break;
        }
        return this.Sprite;
    }

    public Sprite Last()
    {
        switch (_rotationCW)
        {
            case Rotation.ZERO:
                _rotationCW = Rotation.NINETY_CCW;
                break;
            case Rotation.NINETY_CW:
                _rotationCW = Rotation.ZERO;
                break;
            case Rotation.ONE_EIGHTY:
                _rotationCW = Rotation.NINETY_CW;
                break;
            case Rotation.NINETY_CCW:
                _rotationCW = Rotation.ONE_EIGHTY;
                break;
        }
        return this.Sprite;
    }

}