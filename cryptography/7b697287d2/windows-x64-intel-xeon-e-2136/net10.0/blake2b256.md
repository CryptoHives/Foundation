| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |        107.69 ns |       1.569 ns |       1.468 ns |        108.40 ns |   6,263 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        118.01 ns |       2.155 ns |       2.015 ns |        119.31 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        124.37 ns |       0.688 ns |       0.644 ns |        124.54 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        163.14 ns |       2.271 ns |       2.124 ns |        164.26 ns |   8,229 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        938.60 ns |      15.813 ns |      14.792 ns |        944.84 ns |   8,703 B |     1000 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |        106.43 ns |       1.631 ns |       1.526 ns |        106.57 ns |   6,253 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        114.36 ns |       1.786 ns |       1.670 ns |        114.87 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        123.64 ns |       1.988 ns |       1.860 ns |        124.39 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        164.16 ns |       2.501 ns |       2.339 ns |        166.07 ns |   8,219 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        835.78 ns |      13.016 ns |      12.175 ns |        843.10 ns |   8,685 B |     1056 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |        105.51 ns |       1.478 ns |       1.383 ns |        105.74 ns |   6,274 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        113.73 ns |       1.650 ns |       1.543 ns |        114.19 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        123.75 ns |       2.300 ns |       2.152 ns |        125.41 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        162.62 ns |       2.918 ns |       2.729 ns |        164.02 ns |   8,240 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        826.85 ns |      13.333 ns |      12.472 ns |        826.85 ns |   8,763 B |     1064 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |         99.64 ns |       1.544 ns |       1.444 ns |         99.72 ns |   6,247 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        114.14 ns |       1.876 ns |       1.754 ns |        114.83 ns |   5,921 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        128.15 ns |       2.133 ns |       1.995 ns |        129.34 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        156.83 ns |       2.413 ns |       2.257 ns |        157.35 ns |   8,211 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        743.93 ns |      12.771 ns |      11.946 ns |        749.36 ns |   8,710 B |     1120 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        201.55 ns |       3.183 ns |       2.977 ns |        202.78 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        204.65 ns |       3.373 ns |       3.155 ns |        206.20 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        220.41 ns |       2.894 ns |       2.707 ns |        220.27 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        314.87 ns |       5.078 ns |       4.750 ns |        315.66 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,523.11 ns |      24.979 ns |      23.365 ns |      1,538.54 ns |   9,511 B |     1128 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        721.33 ns |      11.682 ns |      10.928 ns |        727.42 ns |   5,915 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        738.40 ns |      11.427 ns |      10.689 ns |        742.58 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        803.95 ns |      12.241 ns |      11.451 ns |        811.98 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,258.18 ns |      18.199 ns |      17.024 ns |      1,255.15 ns |   8,226 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      4,446.18 ns |      75.881 ns |      70.979 ns |      4,459.67 ns |   9,443 B |     2016 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        809.77 ns |      12.963 ns |      12.126 ns |        814.34 ns |   5,893 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |        834.06 ns |      12.616 ns |      11.801 ns |        839.76 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        904.48 ns |      12.009 ns |      11.233 ns |        908.70 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,416.09 ns |      20.207 ns |      18.902 ns |      1,421.83 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      5,207.67 ns |      76.378 ns |      71.444 ns |      5,246.46 ns |   9,501 B |     2024 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,603.13 ns |      65.154 ns |      60.945 ns |      5,626.69 ns |   6,164 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      5,937.38 ns |      81.896 ns |      76.606 ns |      5,976.68 ns |   6,514 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,189.24 ns |      95.975 ns |      89.775 ns |      6,214.43 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      9,653.70 ns |     179.413 ns |     167.823 ns |      9,775.20 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     34,062.15 ns |     603.660 ns |     564.664 ns |     34,385.14 ns |   9,477 B |     9184 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     44,508.33 ns |     759.133 ns |     710.093 ns |     44,716.79 ns |   5,915 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     47,299.06 ns |     803.219 ns |     751.332 ns |     47,452.59 ns |   6,510 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     50,133.10 ns |     689.196 ns |     644.675 ns |     50,448.04 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     77,196.03 ns |   1,375.738 ns |   1,286.866 ns |     78,065.22 ns |   8,480 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    271,894.23 ns |   4,263.881 ns |   3,988.437 ns |    273,925.93 ns |   9,478 B |    66528 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     88,725.90 ns |   1,526.682 ns |   1,428.059 ns |     89,563.45 ns |   6,163 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |     95,009.81 ns |   1,648.134 ns |   1,541.665 ns |     95,724.05 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    100,689.88 ns |   1,412.914 ns |   1,321.640 ns |    101,114.43 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    154,071.85 ns |   2,715.342 ns |   2,539.933 ns |    154,327.86 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    590,085.66 ns |   7,516.234 ns |   7,030.690 ns |    594,054.88 ns |   9,465 B |   132078 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    677,565.56 ns |  11,160.601 ns |  10,439.633 ns |    682,619.92 ns |   5,872 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    728,471.31 ns |  11,700.373 ns |  10,944.537 ns |    734,716.50 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    767,833.30 ns |   9,787.925 ns |   8,676.741 ns |    770,891.85 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,178,565.70 ns |  20,468.522 ns |  19,146.268 ns |  1,191,850.20 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  4,378,034.53 ns |  42,534.409 ns |  39,786.712 ns |  4,398,792.97 ns |   9,501 B |  1001735 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,901,406.35 ns | 115,221.329 ns | 107,778.103 ns |  6,965,719.53 ns |   6,165 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  7,417,140.94 ns | 142,801.891 ns | 133,576.978 ns |  7,490,512.50 ns |   6,533 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  7,855,856.88 ns | 131,467.419 ns | 122,974.705 ns |  7,921,942.19 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 11,941,982.97 ns | 133,488.947 ns | 124,865.644 ns | 12,007,535.16 ns |   8,478 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 42,951,915.00 ns | 652,683.848 ns | 610,520.876 ns | 43,236,616.67 ns |   9,496 B | 10001096 B |