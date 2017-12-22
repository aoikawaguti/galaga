using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beizer : MonoBehaviour {

    [System.Serializable]
    public class Bezier10 : System.Object
    {
        public Vector3 p8;
        public Vector3 p9;
        public Vector3 p10;
        public Vector3 p11;

        public float ti2 = 0f;

        private Vector3 b8 = Vector3.zero;
        private Vector3 b9 = Vector3.zero;
        private Vector3 b10 = Vector3.zero;
        private Vector3 b11 = Vector3.zero;

        private float Hx;
        private float Hy;
        private float Hz;

        private float Ix;
        private float Iy;
        private float Iz;

        private float Jx;
        private float Jy;
        private float Jz;

        public Bezier10(Vector3 v8, Vector3 v9, Vector3 v10, Vector3 v11)
        {
            this.p8 = v8;
            this.p9 = v9;
            this.p10 = v10;
            this.p11 = v11;

        }
        public Vector3 GetPointAtTime2(float t)
        {
            this.CheckConstant2();
            float t2 = t * t;
            float t3 = t * t * t;
            float x2 = this.Hx * t3 + this.Ix * t2 + this.Jx * t + p8.x;
            float y2 = this.Hy * t3 + this.Iy * t2 + this.Jy * t + p8.y;
            float z2 = this.Hz * t3 + this.Iz * t2 + this.Jz * t + p8.z;

            return new Vector3(x2, y2, z2);
        }
        private void SetConstant2()
        {
            this.Jx = 3f * ((this.p8.x + this.p9.x) - this.p8.x);
            this.Ix = 3f * ((this.p11.x + this.p10.x) - (this.p8.x + this.p9.x)) - this.Jx;
            this.Hx = this.p11.x - this.p8.x - this.Jx - this.Ix;
            this.Jy = 3f * ((this.p8.y + this.p9.y) - this.p8.y);
            this.Iy = 3f * ((this.p11.y + this.p10.y) - (this.p8.y + this.p9.y)) - this.Jy;
            this.Hy = this.p11.y - this.p8.y - this.Jy - this.Iy;

            this.Jz = 3f * ((this.p8.z + this.p9.z) - this.p8.z);
            this.Iz = 3f * ((this.p11.z + this.p10.z) - (this.p8.z + this.p9.z)) - this.Jz;
            this.Hz = this.p11.z - this.p8.z - this.Jz - this.Iz;
        }
        private void CheckConstant2()
        {
            if (this.p8 != this.b8 || this.p9 != this.b9 || this.p10 != this.b10 || this.p11 != this.b11)
            {
                this.SetConstant2();
                this.b8 = this.p8;
                this.b9 = this.p9;
                this.b10 = this.p10;
                this.b11 = this.p11;
            }
        }
    }
    //401 アルファベット　数字ともに地続きに制約
}
