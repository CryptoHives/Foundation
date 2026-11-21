| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         75.36 ns |      0.175 ns |      0.164 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         80.80 ns |      0.293 ns |      0.260 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        103.22 ns |      0.123 ns |      0.102 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 4B           |        202.66 ns |      0.161 ns |      0.151 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         74.88 ns |      0.246 ns |      0.230 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         78.91 ns |      0.266 ns |      0.249 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        103.19 ns |      0.346 ns |      0.324 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64B          |        202.62 ns |      0.177 ns |      0.166 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        141.59 ns |      0.536 ns |      0.501 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        157.10 ns |      0.510 ns |      0.452 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        192.03 ns |      0.206 ns |      0.192 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 65B          |        405.50 ns |      0.352 ns |      0.329 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        141.08 ns |      0.479 ns |      0.448 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        156.25 ns |      0.961 ns |      0.899 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        187.09 ns |      0.266 ns |      0.236 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |        405.94 ns |      0.288 ns |      0.270 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        210.02 ns |      0.752 ns |      0.703 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        234.51 ns |      1.102 ns |      1.031 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        283.16 ns |      0.935 ns |      0.875 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 129B         |        609.07 ns |      0.891 ns |      0.833 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,087.95 ns |      5.075 ns |      4.747 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,235.35 ns |      8.193 ns |      7.664 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,425.91 ns |      3.362 ns |      2.980 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |      3,264.59 ns |      8.214 ns |      7.683 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,160.74 ns |      5.198 ns |      4.862 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,311.17 ns |      5.863 ns |      5.484 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,537.19 ns |     30.223 ns |     31.037 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |      3,468.26 ns |      8.941 ns |      7.466 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |      8,660.55 ns |     45.014 ns |     42.106 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |      9,836.98 ns |     47.454 ns |     42.067 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     11,416.52 ns |     34.849 ns |     32.598 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |     26,104.64 ns |     80.897 ns |     75.671 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     69,102.62 ns |    339.606 ns |    317.668 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     78,790.39 ns |    406.299 ns |    380.053 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     92,201.97 ns |    335.487 ns |    313.815 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64KB         |    208,908.71 ns |    381.087 ns |    337.824 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    138,224.06 ns |    676.276 ns |    632.589 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    157,282.32 ns |    973.545 ns |    910.654 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    179,695.07 ns |    479.845 ns |    448.847 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        |    418,049.94 ns |  1,167.933 ns |  1,092.485 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,053,904.29 ns |  6,637.814 ns |  6,209.016 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,202,389.49 ns |  5,920.273 ns |  5,248.168 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,378,886.29 ns |  3,099.758 ns |  2,747.855 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1MB          |  3,187,296.89 ns |  6,889.707 ns |  6,444.636 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 10,537,829.02 ns | 22,941.320 ns | 19,157.041 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 12,046,658.72 ns | 44,965.102 ns | 42,060.384 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 13,683,583.99 ns | 51,493.819 ns | 48,167.350 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 10MB         | 31,882,281.77 ns | 86,688.228 ns | 81,088.222 ns |         - |