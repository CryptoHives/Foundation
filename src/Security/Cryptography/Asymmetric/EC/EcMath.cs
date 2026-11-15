// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// Provides elliptic curve point arithmetic in Jacobian coordinates over short Weierstrass curves.
/// </summary>
/// <remarks>
/// <para>
/// Jacobian coordinates represent the affine point (x, y) as (X, Y, Z) where
/// x = X/Z² and y = Y/Z³. The point at infinity is (1, 1, 0).
/// </para>
/// <para>
/// Using Jacobian coordinates avoids expensive modular inversions during
/// point addition and doubling, deferring a single inversion to the final
/// conversion back to affine coordinates.
/// </para>
/// <para>
/// All operations are constant-time to prevent timing side-channel attacks.
/// </para>
/// </remarks>
internal sealed class EcMath
{
    private readonly MontgomeryContext _field;
    private readonly WeierstrassCurve _curve;
    private readonly int _n;
    private readonly ulong[] _aMont;  // curve coefficient 'a' in Montgomery form
    private readonly bool _aIsMinusThree; // optimization flag for NIST curves

    /// <summary>
    /// Initializes EC math for the given curve.
    /// </summary>
    /// <param name="curve">The Weierstrass curve parameters.</param>
    public EcMath(WeierstrassCurve curve)
    {
        _curve = curve;
        _n = curve.LimbCount;

        Span<ulong> p = stackalloc ulong[_n];
        BigUInt.FromBigEndianBytes(curve.P, p);
        _field = new MontgomeryContext(p);

        // Convert 'a' to Montgomery form
        _aMont = new ulong[_n];
        Span<ulong> a = stackalloc ulong[_n];
        BigUInt.FromBigEndianBytes(curve.A, a);
        _field.ToMontgomery(a, _aMont);

        // Check if a ≡ -3 (mod p) by testing a + 3 == p
        Span<ulong> aPlus3 = stackalloc ulong[_n];
        BigUInt.AddWord(a, 3, aPlus3);
        _aIsMinusThree = BigUInt.ConstantTimeEqual(aPlus3, p);
    }

    /// <summary>
    /// Gets the field Montgomery context.
    /// </summary>
    public MontgomeryContext Field => _field;

    /// <summary>
    /// Gets the curve definition.
    /// </summary>
    public WeierstrassCurve Curve => _curve;

    /// <summary>
    /// Gets the number of limbs for field elements.
    /// </summary>
    public int LimbCount => _n;

    // ========================================================================
    // Point Doubling (Jacobian)
    // ========================================================================

    /// <summary>
    /// Computes point doubling: R = 2·P in Jacobian coordinates.
    /// </summary>
    /// <param name="px">P.X in Montgomery form.</param>
    /// <param name="py">P.Y in Montgomery form.</param>
    /// <param name="pz">P.Z in Montgomery form.</param>
    /// <param name="rx">R.X in Montgomery form (output).</param>
    /// <param name="ry">R.Y in Montgomery form (output).</param>
    /// <param name="rz">R.Z in Montgomery form (output).</param>
    /// <remarks>
    /// Uses the "dbl-2001-b" formula from https://hyperelliptic.org/EFD/g1p/auto-shortw-jacobian.html
    /// Cost: 1M + 5S + 1*a + 7add + 2*2 + 1*3 + 1*8
    /// </remarks>
    public void PointDouble(
        ReadOnlySpan<ulong> px, ReadOnlySpan<ulong> py, ReadOnlySpan<ulong> pz,
        Span<ulong> rx, Span<ulong> ry, Span<ulong> rz)
    {
        int n = _n;
        Span<ulong> t0 = stackalloc ulong[n]; // delta = Z1²
        Span<ulong> t1 = stackalloc ulong[n]; // gamma = Y1²
        Span<ulong> t2 = stackalloc ulong[n]; // beta = X1·gamma
        Span<ulong> t3 = stackalloc ulong[n]; // alpha
        Span<ulong> t4 = stackalloc ulong[n]; // temp
        Span<ulong> t5 = stackalloc ulong[n]; // temp2

        // delta = Z1²
        _field.MontSquare(pz, t0);

        // gamma = Y1²
        _field.MontSquare(py, t1);

        // beta = X1 · gamma
        _field.MontMul(px, t1, t2);

        // alpha = 3·X1² + a·Z1⁴
        if (_aIsMinusThree)
        {
            // Optimized: alpha = 3·(X1 - delta)·(X1 + delta) when a = -3
            _field.ModSub(px, t0, t3);       // X1 - delta
            _field.ModAdd(px, t0, t4);       // X1 + delta
            _field.MontMul(t3, t4, t5);      // (X1-delta)(X1+delta)
            _field.ModAdd(t5, t5, t3);       // 2 * t5
            _field.ModAdd(t3, t5, t3);       // 3 * t5 = alpha
        }
        else
        {
            // General: alpha = 3·X1² + a·Z1⁴
            _field.MontSquare(px, t5);        // X1²
            _field.ModAdd(t5, t5, t3);       // 2·X1²
            _field.ModAdd(t3, t5, t3);       // 3·X1²
            _field.MontSquare(t0, t4);       // Z1⁴
            _field.MontMul(_aMont, t4, t5);  // a·Z1⁴
            _field.ModAdd(t3, t5, t3);       // alpha = 3·X1² + a·Z1⁴
        }

        // X3 = alpha² - 8·beta
        _field.MontSquare(t3, rx);        // alpha²
        _field.ModAdd(t2, t2, t4);       // 2·beta
        _field.ModAdd(t4, t4, t4);       // 4·beta
        _field.ModAdd(t4, t4, t5);       // 8·beta
        _field.ModSub(rx, t5, rx);       // X3 = alpha² - 8·beta

        // Z3 = (Y1 + Z1)² - gamma - delta
        _field.ModAdd(py, pz, rz);       // Y1 + Z1
        _field.MontSquare(rz, rz);       // (Y1+Z1)²
        _field.ModSub(rz, t1, rz);       // - gamma
        _field.ModSub(rz, t0, rz);       // - delta = Z3

        // Y3 = alpha·(4·beta - X3) - 8·gamma²
        _field.ModAdd(t2, t2, t4);       // 2·beta
        _field.ModAdd(t4, t4, t4);       // 4·beta
        _field.ModSub(t4, rx, t4);       // 4·beta - X3
        _field.MontMul(t3, t4, ry);      // alpha·(4·beta - X3)
        _field.MontSquare(t1, t4);       // gamma²
        _field.ModAdd(t4, t4, t4);       // 2·gamma²
        _field.ModAdd(t4, t4, t4);       // 4·gamma²
        _field.ModAdd(t4, t4, t4);       // 8·gamma²
        _field.ModSub(ry, t4, ry);       // Y3
    }

    // ========================================================================
    // Point Addition (Jacobian, mixed)
    // ========================================================================

    /// <summary>
    /// Computes point addition: R = P + Q where Q is in affine (Z=1).
    /// </summary>
    /// <param name="px">P.X in Montgomery form.</param>
    /// <param name="py">P.Y in Montgomery form.</param>
    /// <param name="pz">P.Z in Montgomery form.</param>
    /// <param name="qx">Q.X in Montgomery form (affine).</param>
    /// <param name="qy">Q.Y in Montgomery form (affine).</param>
    /// <param name="rx">R.X in Montgomery form (output).</param>
    /// <param name="ry">R.Y in Montgomery form (output).</param>
    /// <param name="rz">R.Z in Montgomery form (output).</param>
    /// <remarks>
    /// Mixed addition (Q.Z = 1) is faster than general addition.
    /// Uses "madd-2008-g" formula. Does not handle P = Q or P = -Q (use PointDouble for that case).
    /// </remarks>
    public void PointAddMixed(
        ReadOnlySpan<ulong> px, ReadOnlySpan<ulong> py, ReadOnlySpan<ulong> pz,
        ReadOnlySpan<ulong> qx, ReadOnlySpan<ulong> qy,
        Span<ulong> rx, Span<ulong> ry, Span<ulong> rz)
    {
        int n = _n;
        Span<ulong> t0 = stackalloc ulong[n];
        Span<ulong> t1 = stackalloc ulong[n];
        Span<ulong> t2 = stackalloc ulong[n];
        Span<ulong> t3 = stackalloc ulong[n];
        Span<ulong> t4 = stackalloc ulong[n];
        Span<ulong> t5 = stackalloc ulong[n];

        // Z1² and Z1³
        _field.MontSquare(pz, t0);       // Z1²
        _field.MontMul(t0, pz, t1);      // Z1³

        // U2 = X2·Z1²
        _field.MontMul(qx, t0, t2);      // U2

        // S2 = Y2·Z1³
        _field.MontMul(qy, t1, t3);      // S2

        // H = U2 - X1
        _field.ModSub(t2, px, t4);       // H = U2 - X1(=U1)

        // R = S2 - Y1
        _field.ModSub(t3, py, t5);       // R = S2 - Y1(=S1)

        // H² and H³
        _field.MontSquare(t4, t0);       // H²
        _field.MontMul(t0, t4, t1);      // H³

        // U1·H²
        _field.MontMul(px, t0, t2);      // U1·H²

        // X3 = R² - H³ - 2·U1·H²
        _field.MontSquare(t5, rx);       // R²
        _field.ModSub(rx, t1, rx);       // R² - H³
        _field.ModAdd(t2, t2, t3);       // 2·U1·H²
        _field.ModSub(rx, t3, rx);       // X3

        // Y3 = R·(U1·H² - X3) - S1·H³
        _field.ModSub(t2, rx, t3);       // U1·H² - X3
        _field.MontMul(t5, t3, ry);      // R·(U1·H² - X3)
        _field.MontMul(py, t1, t3);      // S1·H³
        _field.ModSub(ry, t3, ry);       // Y3

        // Z3 = Z1·H
        _field.MontMul(pz, t4, rz);      // Z3
    }

    // ========================================================================
    // Scalar Multiplication (constant-time double-and-add)
    // ========================================================================

    /// <summary>
    /// Computes scalar multiplication: R = k·P using constant-time double-and-add-always.
    /// </summary>
    /// <param name="k">The scalar (little-endian limbs).</param>
    /// <param name="px">P.X in Montgomery form (affine).</param>
    /// <param name="py">P.Y in Montgomery form (affine).</param>
    /// <param name="rx">R.X in Montgomery form (output, affine).</param>
    /// <param name="ry">R.Y in Montgomery form (output, affine).</param>
    public void ScalarMul(
        ReadOnlySpan<ulong> k,
        ReadOnlySpan<ulong> px, ReadOnlySpan<ulong> py,
        Span<ulong> rx, Span<ulong> ry)
    {
        int n = _n;

        // Start with point at infinity in Jacobian: (1, 1, 0)
        Span<ulong> accX = stackalloc ulong[n];
        Span<ulong> accY = stackalloc ulong[n];
        Span<ulong> accZ = stackalloc ulong[n];
        SetInfinity(accX, accY, accZ);

        // P in Jacobian form: (px, py, R_mont) where R_mont = 1 in Montgomery form
        Span<ulong> pzMont = stackalloc ulong[n];
        Span<ulong> oneNorm = stackalloc ulong[n];
        oneNorm.Clear();
        oneNorm[0] = 1;
        _field.ToMontgomery(oneNorm, pzMont);

        // Temp for addition/double results
        Span<ulong> tmpX = stackalloc ulong[n];
        Span<ulong> tmpY = stackalloc ulong[n];
        Span<ulong> tmpZ = stackalloc ulong[n];

        int totalBits = BigUInt.BitLength(k);
        if (totalBits == 0)
        {
            rx.Clear();
            ry.Clear();
            return;
        }

        for (int i = totalBits - 1; i >= 0; i--)
        {
            // Always double
            PointDouble(accX, accY, accZ, tmpX, tmpY, tmpZ);
            tmpX.CopyTo(accX);
            tmpY.CopyTo(accY);
            tmpZ.CopyTo(accZ);

            // Check if acc is at infinity (Z = 0) before addition
            ulong accIsInf = BigUInt.IsZero(accZ) ? 1UL : 0UL;

            // Always compute mixed addition (result may be garbage if accZ = 0)
            PointAddMixed(accX, accY, accZ, px, py, tmpX, tmpY, tmpZ);

            // If acc was infinity, override addition result with P in Jacobian
            BigUInt.ConditionalCopy(accIsInf, tmpX, px);
            BigUInt.ConditionalCopy(accIsInf, tmpY, py);
            BigUInt.ConditionalCopy(accIsInf, tmpZ, pzMont);

            // Conditionally use addition result based on the current bit of k
            int limbIdx = i / 64;
            int bitIdx = i % 64;
            ulong bit = limbIdx < k.Length ? (k[limbIdx] >> bitIdx) & 1 : 0;

            BigUInt.ConditionalCopy(bit, accX, tmpX);
            BigUInt.ConditionalCopy(bit, accY, tmpY);
            BigUInt.ConditionalCopy(bit, accZ, tmpZ);
        }

        // Convert from Jacobian to affine: x = X·Z⁻², y = Y·Z⁻³
        ToAffine(accX, accY, accZ, rx, ry);
    }

    /// <summary>
    /// Computes the base point scalar multiplication: R = k·G.
    /// </summary>
    /// <param name="k">The scalar (little-endian limbs).</param>
    /// <param name="rx">R.X in normal form (output, affine big-endian bytes).</param>
    /// <param name="ry">R.Y in normal form (output, affine big-endian bytes).</param>
    public void ScalarMulBase(ReadOnlySpan<ulong> k, Span<byte> rx, Span<byte> ry)
    {
        int n = _n;
        int fieldSize = _curve.FieldSize;

        Span<ulong> gx = stackalloc ulong[n];
        Span<ulong> gy = stackalloc ulong[n];
        Span<ulong> gxMont = stackalloc ulong[n];
        Span<ulong> gyMont = stackalloc ulong[n];

        BigUInt.FromBigEndianBytes(_curve.Gx, gx);
        BigUInt.FromBigEndianBytes(_curve.Gy, gy);
        _field.ToMontgomery(gx, gxMont);
        _field.ToMontgomery(gy, gyMont);

        Span<ulong> outX = stackalloc ulong[n];
        Span<ulong> outY = stackalloc ulong[n];
        ScalarMul(k, gxMont, gyMont, outX, outY);

        // Convert from Montgomery to normal form
        Span<ulong> normX = stackalloc ulong[n];
        Span<ulong> normY = stackalloc ulong[n];
        _field.FromMontgomery(outX, normX);
        _field.FromMontgomery(outY, normY);

        BigUInt.ToBigEndianBytes(normX, rx[..fieldSize]);
        BigUInt.ToBigEndianBytes(normY, ry[..fieldSize]);
    }

    // ========================================================================
    // Point Validation
    // ========================================================================

    /// <summary>
    /// Validates that an affine point (x, y) lies on the curve.
    /// </summary>
    /// <param name="x">X coordinate (big-endian bytes).</param>
    /// <param name="y">Y coordinate (big-endian bytes).</param>
    /// <returns><c>true</c> if the point is on the curve.</returns>
    public bool IsOnCurve(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y)
    {
        int n = _n;

        Span<ulong> xLimbs = stackalloc ulong[n];
        Span<ulong> yLimbs = stackalloc ulong[n];
        Span<ulong> pLimbs = stackalloc ulong[n];

        BigUInt.FromBigEndianBytes(x, xLimbs);
        BigUInt.FromBigEndianBytes(y, yLimbs);
        BigUInt.FromBigEndianBytes(_curve.P, pLimbs);

        // Check x < p and y < p
        if (BigUInt.Compare(xLimbs, pLimbs) >= 0) return false;
        if (BigUInt.Compare(yLimbs, pLimbs) >= 0) return false;

        // Convert to Montgomery form
        Span<ulong> xM = stackalloc ulong[n];
        Span<ulong> yM = stackalloc ulong[n];
        _field.ToMontgomery(xLimbs, xM);
        _field.ToMontgomery(yLimbs, yM);

        // Compute y² mod p
        Span<ulong> y2 = stackalloc ulong[n];
        _field.MontSquare(yM, y2);

        // Compute x³ + ax + b mod p
        Span<ulong> x2 = stackalloc ulong[n];
        Span<ulong> x3 = stackalloc ulong[n];
        Span<ulong> ax = stackalloc ulong[n];
        Span<ulong> rhs = stackalloc ulong[n];
        Span<ulong> bM = stackalloc ulong[n];

        _field.MontSquare(xM, x2);        // x²
        _field.MontMul(x2, xM, x3);       // x³
        _field.MontMul(_aMont, xM, ax);    // a·x

        Span<ulong> bLimbs = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(_curve.B, bLimbs);
        _field.ToMontgomery(bLimbs, bM);

        _field.ModAdd(x3, ax, rhs);       // x³ + a·x
        _field.ModAdd(rhs, bM, rhs);      // x³ + a·x + b

        // y² == x³ + ax + b ?
        Span<ulong> y2Normal = stackalloc ulong[n];
        Span<ulong> rhsNormal = stackalloc ulong[n];
        _field.FromMontgomery(y2, y2Normal);
        _field.FromMontgomery(rhs, rhsNormal);

        return BigUInt.ConstantTimeEqual(y2Normal, rhsNormal);
    }

    // ========================================================================
    // Private Helpers
    // ========================================================================

    /// <summary>
    /// Sets a Jacobian point to infinity (1, 1, 0) in Montgomery form.
    /// </summary>
    private void SetInfinity(Span<ulong> x, Span<ulong> y, Span<ulong> z)
    {
        int n = _n;
        Span<ulong> one = stackalloc ulong[n];
        one.Clear();
        one[0] = 1;
        _field.ToMontgomery(one, x);
        _field.ToMontgomery(one, y);
        z.Clear(); // Z = 0 for point at infinity
    }

    /// <summary>
    /// Converts Jacobian (X, Y, Z) to affine (x, y) in Montgomery form.
    /// x = X·Z⁻², y = Y·Z⁻³
    /// </summary>
    private void ToAffine(
        ReadOnlySpan<ulong> jx, ReadOnlySpan<ulong> jy, ReadOnlySpan<ulong> jz,
        Span<ulong> ax, Span<ulong> ay)
    {
        int n = _n;

        // Compute Z⁻¹ mod p using Fermat's little theorem: Z^(p-2) mod p
        Span<ulong> pLimbs = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(_curve.P, pLimbs);

        Span<ulong> pMinus2 = stackalloc ulong[n];
        BigUInt.SubWord(pLimbs, 2, pMinus2);

        // Z is in Montgomery form; convert to normal for modexp
        Span<ulong> zNormal = stackalloc ulong[n];
        _field.FromMontgomery(jz, zNormal);

        Span<ulong> zInv = stackalloc ulong[n];
        _field.ModExp(zNormal, pMinus2, zInv);

        // Convert Z⁻¹ to Montgomery form
        Span<ulong> zInvMont = stackalloc ulong[n];
        _field.ToMontgomery(zInv, zInvMont);

        // Z⁻²
        Span<ulong> zInv2 = stackalloc ulong[n];
        _field.MontSquare(zInvMont, zInv2);

        // Z⁻³
        Span<ulong> zInv3 = stackalloc ulong[n];
        _field.MontMul(zInv2, zInvMont, zInv3);

        // x = X · Z⁻²
        _field.MontMul(jx, zInv2, ax);

        // y = Y · Z⁻³
        _field.MontMul(jy, zInv3, ay);
    }
}
