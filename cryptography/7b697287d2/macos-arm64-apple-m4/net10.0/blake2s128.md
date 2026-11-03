| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |         73.20 ns |      0.170 ns |      0.159 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |         77.92 ns |      0.382 ns |      0.357 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        103.53 ns |      0.052 ns |      0.048 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 4B           |        198.64 ns |      0.161 ns |      0.150 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |         72.56 ns |      0.430 ns |      0.402 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |         75.81 ns |      0.350 ns |      0.327 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        104.16 ns |      0.148 ns |      0.138 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64B          |        198.79 ns |      0.161 ns |      0.151 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        138.00 ns |      0.424 ns |      0.397 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        151.94 ns |      0.789 ns |      0.738 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        191.78 ns |      0.149 ns |      0.139 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 65B          |        399.96 ns |      0.282 ns |      0.264 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        137.07 ns |      0.526 ns |      0.492 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        151.17 ns |      0.639 ns |      0.598 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        193.48 ns |      0.157 ns |      0.139 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |        399.62 ns |      0.122 ns |      0.095 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        204.95 ns |      0.700 ns |      0.655 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        226.99 ns |      0.668 ns |      0.624 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        282.05 ns |      0.618 ns |      0.578 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 129B         |        601.14 ns |      0.437 ns |      0.341 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,063.22 ns |      3.760 ns |      3.517 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      1,195.37 ns |      5.631 ns |      5.267 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,449.75 ns |      2.319 ns |      2.170 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |      3,216.40 ns |      0.747 ns |      0.662 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,128.90 ns |      3.516 ns |      3.289 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      1,272.34 ns |      5.628 ns |      5.265 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,537.88 ns |      1.082 ns |      0.959 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |      3,417.69 ns |      0.704 ns |      0.659 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |      8,418.79 ns |     30.208 ns |     28.256 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |      9,538.37 ns |     40.800 ns |     38.164 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     11,457.95 ns |     23.886 ns |     22.343 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |     25,750.56 ns |      5.294 ns |      4.693 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     67,181.83 ns |    278.490 ns |    260.499 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |     76,317.39 ns |    318.752 ns |    298.161 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |     91,383.37 ns |    111.062 ns |     98.453 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 64KB         |    205,999.52 ns |     52.477 ns |     49.087 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    134,279.49 ns |    517.513 ns |    484.082 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    152,562.49 ns |    638.209 ns |    596.981 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    183,141.96 ns |    200.193 ns |    187.261 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        |    411,993.71 ns |     59.492 ns |     55.649 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,028,598.63 ns |  5,225.968 ns |  4,888.373 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  1,169,023.72 ns |  5,349.679 ns |  5,004.093 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,403,245.78 ns |  3,577.293 ns |  3,346.202 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1MB          |  3,142,895.02 ns |  1,005.077 ns |    940.150 ns |         - |
|                                                   |              |                  |               |               |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 10,271,580.03 ns | 37,528.843 ns | 35,104.503 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 11,654,303.08 ns | 46,381.054 ns | 43,384.867 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 13,967,657.83 ns | 11,433.720 ns | 10,135.695 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 10MB         | 31,450,545.84 ns | 22,793.307 ns | 21,320.873 ns |         - |