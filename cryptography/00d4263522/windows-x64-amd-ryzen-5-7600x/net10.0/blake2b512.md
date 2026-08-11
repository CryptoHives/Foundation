| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      84.63 ns |   0.241 ns |   0.201 ns |   8,075 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      96.39 ns |   0.274 ns |   0.243 ns |   8,036 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     102.22 ns |   0.206 ns |   0.193 ns |   8,996 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     133.30 ns |   0.259 ns |   0.216 ns |  10,145 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     525.81 ns |   2.595 ns |   2.427 ns |   8,872 B |    1216 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     166.92 ns |   0.536 ns |   0.419 ns |   8,063 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     179.80 ns |   0.527 ns |   0.493 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     187.08 ns |   1.999 ns |   1.772 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     257.69 ns |   0.637 ns |   0.565 ns |  10,137 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     959.87 ns |   4.779 ns |   4.470 ns |   9,221 B |    1232 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     629.88 ns |   1.759 ns |   1.559 ns |   8,083 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     655.25 ns |   1.807 ns |   1.690 ns |   8,053 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     718.78 ns |   2.893 ns |   2.416 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |   1,005.72 ns |   3.275 ns |   3.064 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,159.35 ns |   6.596 ns |   5.508 ns |   9,071 B |    2112 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     712.38 ns |   2.672 ns |   2.232 ns |   8,065 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     730.70 ns |   1.771 ns |   1.570 ns |   8,020 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     804.89 ns |   1.673 ns |   1.565 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,129.20 ns |   2.586 ns |   2.019 ns |  10,139 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,592.67 ns |  11.053 ns |   9.798 ns |   9,112 B |    2120 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   4,999.21 ns |   8.710 ns |   8.147 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,092.08 ns |  16.397 ns |  13.693 ns |   8,292 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,608.28 ns |  19.942 ns |  15.570 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   8,011.09 ns |  19.734 ns |  17.494 ns |  10,140 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  24,161.87 ns |  75.604 ns |  67.021 ns |   9,110 B |    9280 B |
|                                                   |              |               |            |            |           |           |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  80,850.19 ns | 327.782 ns | 290.570 ns |   8,295 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  83,820.87 ns | 153.159 ns | 143.265 ns |   8,073 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  89,114.02 ns | 296.303 ns | 262.665 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 128,020.20 ns | 328.947 ns | 307.698 ns |  10,142 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 411,745.95 ns | 547.781 ns | 427.672 ns |   9,133 B |  132174 B |