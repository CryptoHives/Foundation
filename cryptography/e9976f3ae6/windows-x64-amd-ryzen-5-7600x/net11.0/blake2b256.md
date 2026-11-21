| Description                                       | TestDataSize | Mean             | Error         | StdDev        | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |         99.08 ns |      0.076 ns |      0.071 ns |  14,670 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        108.83 ns |      0.207 ns |      0.183 ns |  15,162 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        117.83 ns |      0.157 ns |      0.139 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        153.62 ns |      0.251 ns |      0.209 ns |  17,095 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        620.99 ns |      1.985 ns |      1.760 ns |  20,263 B |      992 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |         92.49 ns |      0.066 ns |      0.055 ns |  14,472 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        114.93 ns |      0.180 ns |      0.160 ns |   7,351 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        122.37 ns |      0.212 ns |      0.198 ns |  14,962 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        152.73 ns |      0.372 ns |      0.330 ns |  17,087 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        600.05 ns |      2.733 ns |      2.423 ns |  20,405 B |     1048 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |         98.36 ns |      0.089 ns |      0.083 ns |  14,472 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        119.18 ns |      0.161 ns |      0.142 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        127.56 ns |      0.151 ns |      0.134 ns |   8,629 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        153.92 ns |      0.496 ns |      0.414 ns |  17,277 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        589.75 ns |      1.922 ns |      1.605 ns |  47,021 B |     1056 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |         92.32 ns |      0.103 ns |      0.096 ns |  14,918 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        107.81 ns |      0.218 ns |      0.193 ns |  15,244 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        121.88 ns |      0.129 ns |      0.120 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        150.31 ns |      0.347 ns |      0.290 ns |  17,343 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        560.14 ns |      2.319 ns |      2.056 ns |  20,014 B |     1112 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        181.28 ns |      0.180 ns |      0.159 ns |  14,670 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        216.15 ns |      0.154 ns |      0.144 ns |  16,270 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        225.79 ns |      0.138 ns |      0.129 ns |  15,161 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        292.99 ns |      0.669 ns |      0.559 ns |  17,095 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,040.99 ns |      3.492 ns |      3.266 ns |  22,546 B |     1120 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        684.85 ns |      0.629 ns |      0.588 ns |   8,387 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        725.21 ns |      0.549 ns |      0.514 ns |  16,270 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        770.28 ns |      0.525 ns |      0.491 ns |   8,903 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,132.74 ns |      1.770 ns |      1.478 ns |  17,527 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      3,513.20 ns |      8.192 ns |      6.841 ns |  15,004 B |     2008 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |        773.39 ns |      0.565 ns |      0.528 ns |  14,480 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        789.40 ns |      0.523 ns |      0.489 ns |  16,460 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        880.87 ns |      0.625 ns |      0.585 ns |  14,966 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,264.43 ns |      2.579 ns |      2.286 ns |  17,285 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      3,992.94 ns |     10.729 ns |      9.511 ns |  21,860 B |     2016 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      5,437.13 ns |      2.973 ns |      2.635 ns |  14,722 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      5,489.17 ns |      3.771 ns |      3.528 ns |  16,460 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,991.19 ns |      3.002 ns |      2.808 ns |  15,428 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      8,855.73 ns |     11.511 ns |      8.987 ns |  17,337 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     27,008.04 ns |     86.368 ns |     76.563 ns |  24,604 B |     9176 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     43,303.38 ns |     16.102 ns |     14.274 ns |  14,926 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     43,745.70 ns |     20.796 ns |     19.453 ns |  16,270 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     44,945.50 ns |     46.856 ns |     43.829 ns |  15,237 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     71,858.09 ns |     76.585 ns |     63.952 ns |  11,016 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    214,176.76 ns |    427.912 ns |    357.326 ns |  14,496 B |    66520 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |     86,688.32 ns |     46.759 ns |     43.738 ns |  14,926 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |     87,719.77 ns |     65.713 ns |     61.468 ns |   9,935 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     99,728.41 ns |     29.896 ns |     26.502 ns |  15,238 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    141,931.33 ns |    443.095 ns |    370.005 ns |  17,351 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    468,714.94 ns |    613.288 ns |    478.815 ns |  17,295 B |   132110 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    663,206.57 ns |    721.110 ns |    674.527 ns |  14,669 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    669,401.66 ns |    266.785 ns |    236.498 ns |   7,351 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    730,242.13 ns |    403.178 ns |    357.407 ns |  14,963 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,080,917.94 ns |  2,032.779 ns |  1,802.006 ns |  17,284 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,386,849.11 ns |  8,273.226 ns |  7,738.780 ns |  24,005 B |  1001960 B |
|                                                   |              |                  |               |               |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  6,616,148.38 ns |  3,365.260 ns |  2,983.216 ns |  14,680 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  6,687,321.15 ns |  1,638.005 ns |  1,452.049 ns |  16,677 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,852,729.38 ns |  3,145.120 ns |  2,941.947 ns |  16,810 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 10,829,569.42 ns | 24,503.278 ns | 21,721.518 ns |  17,534 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 33,144,957.69 ns | 48,434.188 ns | 40,444.740 ns |  20,992 B | 10001382 B |