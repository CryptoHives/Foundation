| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      84.70 ns |   0.326 ns |   0.289 ns |   8,075 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      96.35 ns |   0.357 ns |   0.298 ns |   8,036 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |      97.95 ns |   0.143 ns |   0.127 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     130.31 ns |   0.387 ns |   0.323 ns |  10,143 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     496.13 ns |   2.491 ns |   2.080 ns |   8,878 B |    1120 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     167.28 ns |   0.372 ns |   0.330 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     177.37 ns |   0.468 ns |   0.415 ns |   8,004 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     187.21 ns |   0.684 ns |   0.640 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     253.41 ns |   0.337 ns |   0.281 ns |  10,130 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     914.65 ns |   4.100 ns |   3.835 ns |   9,190 B |    1136 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     628.07 ns |   1.377 ns |   1.220 ns |   8,081 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     651.24 ns |   1.667 ns |   1.392 ns |   8,290 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     719.11 ns |   8.118 ns |   6.779 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     987.15 ns |   1.629 ns |   1.444 ns |  10,147 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,123.64 ns |   9.626 ns |   9.005 ns |   9,075 B |    2016 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     710.70 ns |   1.199 ns |   1.001 ns |   8,065 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     735.40 ns |   2.055 ns |   1.822 ns |   8,020 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     801.42 ns |   1.941 ns |   1.621 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,149.07 ns |   1.979 ns |   1.851 ns |  10,132 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,500.53 ns |   5.404 ns |   4.790 ns |   9,116 B |    2024 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   5,012.47 ns | 100.144 ns |  78.186 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,064.20 ns |  11.146 ns |   9.308 ns |   8,290 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,665.31 ns |  15.126 ns |  12.631 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,858.73 ns |  11.895 ns |  10.545 ns |  10,138 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  23,862.88 ns |  70.667 ns |  66.102 ns |   9,110 B |    9184 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  79,751.82 ns | 483.131 ns | 377.197 ns |   8,078 B |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  81,077.22 ns | 246.346 ns | 230.432 ns |   8,289 B |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  88,918.06 ns | 240.077 ns | 200.475 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 126,224.99 ns | 351.741 ns | 329.019 ns |  10,138 B |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 405,984.33 ns | 531.942 ns | 444.195 ns |   9,096 B |  132078 B |