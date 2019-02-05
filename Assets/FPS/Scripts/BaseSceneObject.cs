using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseSceneObject : MonoBehaviour
    {  
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                name = _name;
            }
        }

        protected int _layer;
        public int Layers
        {
            get
            {
                return _layer;
            }
            set
            {
                _layer = value;
                //Layers(transform, _layer);
            }
        }

        protected Renderer _renderer;
        protected Color _color;
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;               
                _material.color = _color;                           
            }
        }

        protected Material _material;
        public Material GetMaterial
        {
            get { return _material; }
        } 

        protected Rigidbody _rigidbody;
        public Rigidbody Rigidbody
        {
            get { return _rigidbody; }
        }

        protected GameObject _gameObject;
        public GameObject GameObject
        {
            get { return _gameObject; }
        }


        protected Collider _collider;
        public Collider Collider
        {
            get
            {
                if (!_collider) _collider = GetComponent<Collider>();
                return _collider;
            }
        }

        protected Transform _transform;
        public Transform Transform
        {
            get
            {
                if (!_transform) _transform = transform;
                return _transform;
            }

        }

        protected bool _isVisible;
        public bool IsVisible
        {
            get
            {
                if (!_renderer) return false;
                return _renderer.enabled;
            }
            set
            {
                _isVisible = value;
                SetVisibility(Transform , _isVisible);
            }
        }

        protected virtual void Awake()
        {
            _gameObject = GetComponent<GameObject>();
            _rigidbody = GetComponent<Rigidbody>();
            Name = name;
            _layer = gameObject.layer;
            _renderer= GetComponent<Renderer>();

            if (_renderer)
                _material = _renderer.material;
            if (_material)
                _color = _material.color;
        }

        private void SetVisibility(Transform objTransform, bool visible) 
        {
            var rend = objTransform.GetComponent<Renderer>(); 
            if (rend)
            rend.enabled = visible;
        
            foreach (var r in GetComponentsInChildren<Renderer>(true))
            r.enabled = visible;
        }
    }
}

