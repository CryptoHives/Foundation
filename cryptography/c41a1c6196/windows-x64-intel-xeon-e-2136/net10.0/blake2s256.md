| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Median           | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 4B           |        104.21 ns |      0.139 ns |      0.265 ns |        104.26 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 4B           |        119.60 ns |      0.834 ns |      1.566 ns |        120.39 ns |   2,966 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 4B           |        125.32 ns |      0.196 ns |      0.374 ns |        125.12 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 4B           |        143.21 ns |      0.204 ns |      0.389 ns |        143.14 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 4B           |        158.13 ns |      0.296 ns |      0.564 ns |        158.01 ns |   6,653 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64B          |         99.19 ns |      0.304 ns |      0.578 ns |         99.08 ns |   2,963 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64B          |        114.46 ns |      0.795 ns |      1.512 ns |        113.54 ns |   2,958 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64B          |        126.46 ns |      1.011 ns |      1.797 ns |        126.00 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64B          |        143.33 ns |      0.081 ns |      0.150 ns |        143.32 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64B          |        155.61 ns |      0.977 ns |      1.859 ns |        155.61 ns |   6,639 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 65B          |        201.57 ns |      0.510 ns |      0.945 ns |        201.65 ns |   2,979 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 65B          |        225.87 ns |      0.250 ns |      0.476 ns |        226.06 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 65B          |        229.99 ns |      0.914 ns |      1.672 ns |        228.94 ns |   2,970 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 65B          |        245.93 ns |      0.833 ns |      1.565 ns |        244.94 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 65B          |        305.34 ns |      0.450 ns |      0.857 ns |        305.67 ns |   6,643 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |        192.54 ns |      1.249 ns |      2.376 ns |        191.14 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |        219.18 ns |      0.244 ns |      0.465 ns |        219.19 ns |   2,964 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |        224.60 ns |      0.240 ns |      0.451 ns |        224.72 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |        245.39 ns |      0.136 ns |      0.256 ns |        245.38 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |        298.20 ns |      0.505 ns |      0.960 ns |        298.23 ns |   6,669 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 129B         |        292.16 ns |      0.585 ns |      1.084 ns |        291.95 ns |   2,968 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 129B         |        321.22 ns |      0.148 ns |      0.282 ns |        321.19 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 129B         |        338.91 ns |      1.676 ns |      2.978 ns |        339.39 ns |   2,966 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 129B         |        347.40 ns |      0.182 ns |      0.342 ns |        347.23 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 129B         |        448.87 ns |      0.618 ns |      1.175 ns |        449.26 ns |   6,643 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |      1,466.41 ns |      2.133 ns |      4.059 ns |      1,465.90 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |      1,631.51 ns |      0.407 ns |      0.775 ns |      1,631.52 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |      1,682.35 ns |      1.186 ns |      2.228 ns |      1,682.70 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |      1,750.59 ns |      0.571 ns |      1.059 ns |      1,750.57 ns |   2,981 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |      2,358.44 ns |      3.496 ns |      6.652 ns |      2,359.66 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |      1,629.39 ns |      0.512 ns |      0.937 ns |      1,629.05 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |      1,696.26 ns |      0.853 ns |      1.560 ns |      1,695.84 ns |   5,385 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |      1,789.15 ns |      0.975 ns |      1.807 ns |      1,789.23 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |      1,857.77 ns |      1.049 ns |      1.995 ns |      1,857.36 ns |   2,955 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |      2,512.21 ns |      3.988 ns |      7.588 ns |      2,513.92 ns |   6,643 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |     11,646.88 ns |     10.795 ns |     20.538 ns |     11,653.63 ns |   2,983 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |     12,276.50 ns |     15.724 ns |     29.916 ns |     12,278.13 ns |   5,404 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |     13,162.59 ns |      4.849 ns |      9.225 ns |     13,160.56 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |     13,442.95 ns |      6.001 ns |     10.974 ns |     13,444.19 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |     18,483.75 ns |     43.018 ns |     81.846 ns |     18,478.28 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 64KB         |     93,903.88 ns |    185.182 ns |    352.328 ns |     93,837.00 ns |   3,225 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 64KB         |     97,432.75 ns |     37.595 ns |     68.745 ns |     97,434.99 ns |   5,653 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 64KB         |    105,814.93 ns |    303.894 ns |    578.189 ns |    105,735.44 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 64KB         |    108,308.53 ns |    206.282 ns |    387.448 ns |    108,224.41 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 64KB         |    147,265.45 ns |    258.032 ns |    490.933 ns |    147,386.99 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        |    186,856.79 ns |    180.878 ns |    344.139 ns |    186,949.54 ns |   3,225 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        |    194,750.42 ns |     80.932 ns |    150.013 ns |    194,710.42 ns |   5,653 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        |    211,677.61 ns |    524.544 ns |    997.999 ns |    211,362.26 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        |    215,765.20 ns |    274.499 ns |    508.802 ns |    215,501.78 ns |   3,213 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        |    295,051.68 ns |    569.605 ns |  1,083.733 ns |    295,515.28 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1MB          |  1,433,290.52 ns |  2,336.487 ns |  4,445.409 ns |  1,434,152.15 ns |   3,232 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1MB          |  1,486,345.71 ns |    712.575 ns |  1,338.389 ns |  1,486,150.10 ns |   5,658 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1MB          |  1,615,393.01 ns |  2,763.871 ns |  5,123.013 ns |  1,614,372.07 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1MB          |  1,655,035.98 ns |    664.301 ns |  1,231.324 ns |  1,655,107.71 ns |   3,220 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1MB          |  2,255,035.27 ns |  4,342.048 ns |  8,261.198 ns |  2,255,845.31 ns |   6,901 B |         - |
|                                                   |              |                  |               |               |                  |           |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 10MB         | 14,432,741.61 ns | 50,005.020 ns | 92,687.517 ns | 14,380,131.25 ns |   3,257 B |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 10MB         | 14,949,887.65 ns |  5,630.657 ns | 10,295.976 ns | 14,949,742.97 ns |   5,660 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 10MB         | 16,344,580.90 ns | 44,463.447 ns | 84,596.335 ns | 16,381,153.12 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 10MB         | 16,538,707.15 ns | 10,426.124 ns | 19,836.786 ns | 16,543,828.12 ns |   3,238 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 10MB         | 22,678,983.96 ns | 45,040.084 ns | 85,693.447 ns | 22,664,693.75 ns |   6,926 B |         - |