| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Median        | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      84.50 ns |   0.201 ns |   0.178 ns |      84.51 ns |   8,075 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      97.80 ns |   0.315 ns |   0.263 ns |      97.76 ns |   8,036 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     102.95 ns |   0.233 ns |   0.207 ns |     102.94 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     131.73 ns |   0.333 ns |   0.295 ns |     131.65 ns |  10,142 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     519.03 ns |   1.425 ns |   1.263 ns |     518.88 ns |   8,868 B |    1216 B |
|                                                   |              |               |            |            |               |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     167.31 ns |   0.453 ns |   0.402 ns |     167.24 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     188.51 ns |   1.153 ns |   0.963 ns |     188.54 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     210.49 ns |   0.670 ns |   0.627 ns |     210.66 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     254.23 ns |   0.435 ns |   0.386 ns |     254.20 ns |  10,130 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     944.21 ns |   4.022 ns |   3.359 ns |     942.97 ns |   9,236 B |    1232 B |
|                                                   |              |               |            |            |               |           |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     653.43 ns |   1.968 ns |   1.644 ns |     653.43 ns |   8,049 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     656.28 ns |  14.631 ns |  43.139 ns |     630.67 ns |   8,087 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     715.37 ns |   1.462 ns |   1.368 ns |     715.34 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     994.68 ns |   1.926 ns |   1.707 ns |     994.72 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,113.49 ns |   9.994 ns |   9.348 ns |   3,110.96 ns |   9,071 B |    2112 B |
|                                                   |              |               |            |            |               |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     711.42 ns |   1.498 ns |   1.401 ns |     711.69 ns |   8,065 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     731.23 ns |   1.983 ns |   1.855 ns |     731.13 ns |   8,020 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     797.06 ns |   2.257 ns |   2.000 ns |     797.46 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,116.46 ns |   3.044 ns |   2.542 ns |   1,116.33 ns |  10,142 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,537.37 ns |  11.383 ns |   9.505 ns |   3,536.84 ns |   9,116 B |    2120 B |
|                                                   |              |               |            |            |               |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   4,984.27 ns |  14.650 ns |  11.438 ns |   4,985.48 ns |   8,083 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,073.47 ns |  20.481 ns |  18.156 ns |   5,072.55 ns |   8,292 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,587.47 ns |  14.663 ns |  12.245 ns |   5,583.91 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   7,854.84 ns |  11.500 ns |   9.603 ns |   7,855.40 ns |  10,146 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  23,867.91 ns |  53.925 ns |  47.803 ns |  23,861.60 ns |   9,110 B |    9280 B |
|                                                   |              |               |            |            |               |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  79,652.20 ns | 240.229 ns | 224.710 ns |  79,632.47 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  80,805.32 ns | 229.294 ns | 203.263 ns |  80,815.05 ns |   8,295 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  89,080.91 ns | 377.764 ns | 315.450 ns |  89,126.25 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 126,261.57 ns | 239.615 ns | 224.136 ns | 126,230.76 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 406,799.76 ns | 769.458 ns | 642.533 ns | 406,749.80 ns |   9,108 B |  132174 B |