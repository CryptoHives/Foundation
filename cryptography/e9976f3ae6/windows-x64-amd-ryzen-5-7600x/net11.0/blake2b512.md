| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |        100.51 ns |      0.056 ns |      0.053 ns |  14,670 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        108.00 ns |      0.189 ns |      0.177 ns |  15,162 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        133.74 ns |      0.144 ns |      0.135 ns |  16,460 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        153.77 ns |      0.621 ns |      0.551 ns |  10,760 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        643.02 ns |      1.951 ns |      1.729 ns |  20,031 B |     1088 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |         92.28 ns |      0.080 ns |      0.071 ns |  14,472 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        115.75 ns |      0.069 ns |      0.057 ns |  16,460 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        130.39 ns |      0.079 ns |      0.061 ns |  15,154 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        153.38 ns |      0.378 ns |      0.336 ns |  17,277 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        613.86 ns |      2.639 ns |      2.339 ns |  21,265 B |     1144 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |         96.64 ns |      0.080 ns |      0.066 ns |   8,137 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        118.88 ns |      0.134 ns |      0.125 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        130.65 ns |      0.091 ns |      0.076 ns |  14,964 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        153.23 ns |      0.430 ns |      0.381 ns |  17,277 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        618.04 ns |      2.036 ns |      1.904 ns |  15,058 B |     1152 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |         92.96 ns |      0.107 ns |      0.090 ns |   8,393 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        104.74 ns |      0.183 ns |      0.171 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        128.97 ns |      0.105 ns |      0.082 ns |   8,909 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        151.04 ns |      0.308 ns |      0.257 ns |  17,533 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        584.95 ns |      1.365 ns |      1.140 ns |  25,539 B |     1208 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        183.16 ns |      0.095 ns |      0.079 ns |  14,670 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        199.42 ns |      0.183 ns |      0.171 ns |  14,972 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        217.13 ns |      0.121 ns |      0.107 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        294.44 ns |      0.395 ns |      0.309 ns |  17,285 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,069.96 ns |      1.973 ns |      1.540 ns |  20,877 B |     1216 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        685.88 ns |      0.518 ns |      0.484 ns |   8,387 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        738.51 ns |      0.352 ns |      0.294 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        774.91 ns |      0.577 ns |      0.540 ns |  15,238 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,132.66 ns |      2.853 ns |      2.529 ns |  17,337 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      3,542.94 ns |      7.914 ns |      7.015 ns |  21,288 B |     2104 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |        772.78 ns |      0.350 ns |      0.328 ns |   8,145 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        801.48 ns |      0.808 ns |      0.675 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        810.78 ns |      0.603 ns |      0.564 ns |  14,965 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,257.29 ns |      2.222 ns |      1.969 ns |  17,285 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,018.75 ns |     11.071 ns |     10.356 ns |  20,809 B |     2112 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      5,414.47 ns |      4.563 ns |      4.268 ns |   8,387 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      5,537.93 ns |      2.793 ns |      2.612 ns |  16,460 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      6,120.11 ns |      6.852 ns |      6.410 ns |  16,815 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      8,866.14 ns |     26.327 ns |     23.338 ns |  17,527 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     27,032.49 ns |     53.431 ns |     44.617 ns |  26,072 B |     9272 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     43,302.45 ns |     24.165 ns |     21.421 ns |  14,736 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     43,744.48 ns |     16.607 ns |     14.722 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     44,723.00 ns |     27.307 ns |     25.543 ns |  15,428 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     70,448.02 ns |    158.251 ns |    140.285 ns |  17,541 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    215,343.84 ns |    512.089 ns |    453.954 ns |  21,055 B |    66616 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |     86,563.12 ns |     29.672 ns |     24.778 ns |  14,736 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |     87,705.03 ns |     44.176 ns |     41.322 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     89,542.37 ns |     36.491 ns |     34.134 ns |   8,903 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    140,853.63 ns |    368.157 ns |    326.362 ns |  11,016 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    469,231.43 ns |    938.335 ns |    783.552 ns |  14,595 B |   132206 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    662,494.70 ns |    195.034 ns |    162.862 ns |   8,144 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    670,363.52 ns |    293.939 ns |    274.951 ns |  16,460 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    686,024.28 ns |    251.881 ns |    210.332 ns |  15,153 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,078,011.73 ns |  2,570.520 ns |  2,146.501 ns |  17,284 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  3,383,181.14 ns | 11,015.781 ns |  9,765.203 ns |  20,999 B |  1002062 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  6,617,446.51 ns |  4,592.868 ns |  4,296.172 ns |   8,305 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  6,702,864.90 ns |  2,024.880 ns |  1,894.074 ns |  16,272 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,853,277.73 ns |  1,801.356 ns |  1,596.855 ns |   8,903 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 10,842,401.23 ns | 39,252.938 ns | 34,796.707 ns |  11,009 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 33,192,873.75 ns | 73,201.666 ns | 68,472.883 ns |  27,326 B | 10001478 B |