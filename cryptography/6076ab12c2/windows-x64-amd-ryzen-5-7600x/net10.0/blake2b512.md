| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |         98.14 ns |      0.155 ns |      0.138 ns |   5,573 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        114.64 ns |      0.422 ns |      0.395 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        114.74 ns |      0.562 ns |      0.526 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        153.19 ns |      0.839 ns |      0.744 ns |   8,188 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        645.86 ns |      6.986 ns |      6.535 ns |   8,701 B |     1096 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |         92.16 ns |      0.267 ns |      0.250 ns |   5,563 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        114.88 ns |      0.523 ns |      0.489 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        115.73 ns |      0.538 ns |      0.503 ns |   6,239 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        152.88 ns |      1.180 ns |      1.046 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        625.33 ns |      5.382 ns |      5.034 ns |   8,665 B |     1152 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |         95.77 ns |      0.244 ns |      0.229 ns |   5,568 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        114.46 ns |      0.530 ns |      0.496 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        115.20 ns |      0.498 ns |      0.466 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        152.04 ns |      1.125 ns |      1.052 ns |   8,192 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        622.26 ns |      8.759 ns |      8.193 ns |   8,648 B |     1160 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |         91.91 ns |      0.178 ns |      0.167 ns |   5,582 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        106.50 ns |      0.196 ns |      0.183 ns |   6,282 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        116.56 ns |      0.710 ns |      0.664 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        149.68 ns |      0.900 ns |      0.842 ns |   8,204 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        590.38 ns |      7.042 ns |      6.588 ns |   8,659 B |     1216 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        183.97 ns |      0.264 ns |      0.247 ns |   5,566 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        196.72 ns |      0.518 ns |      0.485 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        209.53 ns |      0.689 ns |      0.644 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        293.79 ns |      2.156 ns |      2.017 ns |   8,170 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,079.42 ns |     15.128 ns |     14.150 ns |   9,427 B |     1224 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        685.34 ns |      0.884 ns |      0.827 ns |   5,564 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        721.25 ns |      0.719 ns |      0.673 ns |   6,276 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        792.66 ns |      0.953 ns |      0.891 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,125.29 ns |      7.362 ns |      6.886 ns |   8,119 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      3,615.97 ns |     38.301 ns |     33.952 ns |   9,344 B |     2112 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |        775.51 ns |      1.146 ns |      1.072 ns |   5,555 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        812.01 ns |      0.650 ns |      0.608 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        885.74 ns |      1.219 ns |      1.140 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,269.95 ns |     10.072 ns |      9.422 ns |   8,181 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,049.33 ns |     40.584 ns |     37.962 ns |   9,380 B |     2120 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      5,435.34 ns |      7.403 ns |      6.925 ns |   5,818 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,638.90 ns |      4.174 ns |      3.904 ns |   6,519 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,179.79 ns |      3.303 ns |      3.090 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      8,910.28 ns |     76.311 ns |     67.648 ns |   8,433 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     27,274.15 ns |    281.854 ns |    263.646 ns |   9,397 B |     9280 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     43,443.29 ns |     62.713 ns |     58.662 ns |   5,818 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     44,864.87 ns |     41.541 ns |     38.858 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     49,430.17 ns |     41.543 ns |     38.859 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     71,368.96 ns |    504.479 ns |    471.890 ns |   8,422 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    215,748.40 ns |  1,621.873 ns |  1,517.101 ns |   9,404 B |    66624 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |     86,884.01 ns |     97.078 ns |     90.806 ns |   5,818 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     89,517.32 ns |     44.612 ns |     39.547 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |     99,275.15 ns |     66.201 ns |     61.925 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    142,835.37 ns |    890.737 ns |    833.196 ns |   8,440 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    458,879.70 ns |    775.241 ns |    687.231 ns |   9,422 B |   132174 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    661,965.18 ns |    303.262 ns |    283.671 ns |   5,545 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    684,437.24 ns |    254.825 ns |    225.896 ns |   6,227 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    757,666.06 ns |    439.927 ns |    411.508 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,079,629.37 ns |  1,645.088 ns |  1,538.817 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  3,354,229.48 ns |  7,319.786 ns |  6,846.933 ns |   9,416 B |  1001919 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  6,625,494.95 ns |  2,703.813 ns |  2,529.148 ns |   5,825 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,866,177.81 ns |  2,587.310 ns |  2,420.171 ns |   6,520 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  7,562,670.81 ns |  5,533.615 ns |  5,176.147 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 10,799,788.06 ns | 19,888.828 ns | 17,630.928 ns |   8,451 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 33,402,842.38 ns | 98,015.929 ns | 86,888.568 ns |   9,411 B | 10001192 B |