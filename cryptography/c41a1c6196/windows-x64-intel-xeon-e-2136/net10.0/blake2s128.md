| Description                                       | TestDataSize | Mean             | Error         | StdDev         | Median           | Code Size | Allocated |
|-------------------------------------------------- |------------- |-----------------:|--------------:|---------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 4B           |        103.85 ns |      0.340 ns |       0.623 ns |        103.98 ns |   2,966 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 4B           |        117.36 ns |      0.161 ns |       0.302 ns |        117.35 ns |   2,961 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 4B           |        126.05 ns |      0.578 ns |       1.071 ns |        125.80 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 4B           |        136.88 ns |      0.303 ns |       0.570 ns |        136.53 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 4B           |        157.74 ns |      0.210 ns |       0.395 ns |        157.87 ns |   6,675 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64B          |         98.68 ns |      0.344 ns |       0.638 ns |         98.77 ns |   2,961 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64B          |        113.30 ns |      0.201 ns |       0.372 ns |        113.40 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64B          |        123.94 ns |      0.287 ns |       0.525 ns |        123.92 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64B          |        139.48 ns |      0.987 ns |       1.854 ns |        140.01 ns |   5,927 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64B          |        154.12 ns |      1.082 ns |       2.059 ns |        153.08 ns |   6,639 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 65B          |        201.73 ns |      1.016 ns |       1.934 ns |        200.72 ns |   2,963 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 65B          |        226.44 ns |      0.155 ns |       0.288 ns |        226.47 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 65B          |        231.16 ns |      1.534 ns |       2.844 ns |        230.41 ns |   2,964 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 65B          |        238.70 ns |      0.139 ns |       0.251 ns |        238.72 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 65B          |        304.28 ns |      0.483 ns |       0.920 ns |        304.57 ns |   6,641 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |        195.50 ns |      1.729 ns |       3.247 ns |        196.38 ns |   2,978 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |        219.28 ns |      0.183 ns |       0.348 ns |        219.22 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |        224.55 ns |      0.038 ns |       0.069 ns |        224.53 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |        241.12 ns |      1.207 ns |       2.267 ns |        239.90 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |        299.06 ns |      0.706 ns |       1.343 ns |        298.93 ns |   6,661 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 129B         |        294.07 ns |      1.512 ns |       2.803 ns |        295.05 ns |   2,966 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 129B         |        321.83 ns |      0.201 ns |       0.373 ns |        321.85 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 129B         |        335.31 ns |      1.167 ns |       2.105 ns |        334.12 ns |   2,969 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 129B         |        344.43 ns |      1.296 ns |       2.434 ns |        344.09 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 129B         |        452.46 ns |      1.379 ns |       2.624 ns |        453.52 ns |   6,639 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |      1,468.94 ns |      3.533 ns |       6.636 ns |      1,469.25 ns |   2,981 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |      1,630.97 ns |      0.210 ns |       0.389 ns |      1,630.97 ns |   5,403 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |      1,675.32 ns |      1.317 ns |       2.407 ns |      1,675.76 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |      1,746.42 ns |      1.780 ns |       3.342 ns |      1,747.71 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |      2,363.66 ns |      3.382 ns |       6.268 ns |      2,363.09 ns |   6,906 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |      1,629.16 ns |      0.577 ns |       1.055 ns |      1,629.13 ns |   2,963 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |      1,697.14 ns |      1.202 ns |       2.257 ns |      1,697.35 ns |   5,381 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |      1,785.03 ns |      4.030 ns |       7.569 ns |      1,786.26 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |      1,861.66 ns |      0.543 ns |       1.020 ns |      1,861.49 ns |   2,951 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |      2,518.54 ns |      4.141 ns |       7.879 ns |      2,517.42 ns |   6,653 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |     11,651.36 ns |      9.164 ns |      17.436 ns |     11,658.08 ns |   2,974 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |     12,240.75 ns |      4.368 ns |       7.877 ns |     12,239.85 ns |   5,652 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |     13,180.78 ns |     13.597 ns |      25.203 ns |     13,184.26 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |     13,469.24 ns |      5.636 ns |      10.447 ns |     13,466.80 ns |   2,976 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |     18,477.11 ns |     34.853 ns |      66.312 ns |     18,482.10 ns |   6,899 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 64KB         |     93,825.67 ns |    141.358 ns |     265.505 ns |     93,824.58 ns |   3,233 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 64KB         |     97,423.66 ns |     36.215 ns |      67.128 ns |     97,406.92 ns |   5,651 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 64KB         |    106,118.77 ns |    480.364 ns |     866.196 ns |    105,671.58 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 64KB         |    108,200.56 ns |     57.540 ns |     108.074 ns |    108,225.41 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 64KB         |    148,015.42 ns |    269.518 ns |     512.787 ns |    148,011.94 ns |   6,899 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        |    187,211.75 ns |    190.040 ns |     356.941 ns |    187,121.92 ns |   3,223 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |    194,794.98 ns |     85.457 ns |     162.591 ns |    194,755.49 ns |   5,656 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |    211,623.40 ns |    459.964 ns |     875.129 ns |    211,566.72 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        |    216,575.74 ns |    915.638 ns |   1,742.097 ns |    215,422.56 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |    297,602.61 ns |  1,195.881 ns |   2,275.289 ns |    296,620.61 ns |   6,899 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1MB          |  1,429,819.57 ns |  1,146.155 ns |   2,180.679 ns |  1,430,107.81 ns |   3,230 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1MB          |  1,487,440.64 ns |  1,151.736 ns |   2,163.240 ns |  1,486,727.64 ns |   5,657 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1MB          |  1,613,280.94 ns |  1,422.575 ns |   2,565.197 ns |  1,613,196.68 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1MB          |  1,656,083.31 ns |  8,502.038 ns |  15,759.073 ns |  1,646,199.22 ns |   3,211 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1MB          |  2,266,738.22 ns |  6,218.407 ns |  11,831.167 ns |  2,263,388.87 ns |   6,899 B |         - |
|                                                   |              |                  |               |                |                  |           |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 10MB         | 14,410,269.71 ns | 16,201.510 ns |  30,430.365 ns | 14,416,204.69 ns |   3,236 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 10MB         | 15,027,801.74 ns | 72,450.402 ns | 136,079.427 ns | 14,937,812.50 ns |   5,658 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 10MB         | 16,322,283.70 ns | 48,411.442 ns |  90,928.430 ns | 16,331,253.12 ns |   5,939 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 10MB         | 16,528,425.43 ns | 11,056.770 ns |  20,767.295 ns | 16,528,437.50 ns |   3,210 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 10MB         | 22,615,057.12 ns | 37,825.023 ns |  70,111.112 ns | 22,634,384.38 ns |   6,909 B |         - |