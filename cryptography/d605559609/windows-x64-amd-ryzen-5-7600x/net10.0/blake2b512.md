| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      83.88 ns |     0.254 ns |     0.225 ns |   7,806 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      97.86 ns |     0.332 ns |     0.295 ns |   8,036 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     101.35 ns |     1.279 ns |     1.133 ns |   9,008 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     132.65 ns |     0.535 ns |     0.500 ns |  10,197 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     518.52 ns |     4.825 ns |     4.277 ns |   8,868 B |    1216 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     169.47 ns |     2.507 ns |     2.222 ns |   7,794 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     177.82 ns |     0.700 ns |     0.584 ns |   8,005 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     182.52 ns |     3.082 ns |     2.883 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     255.54 ns |     1.850 ns |     1.640 ns |  10,198 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     947.01 ns |    14.867 ns |    13.179 ns |   9,245 B |    1232 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     626.97 ns |     2.723 ns |     2.274 ns |   7,811 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     650.90 ns |     1.779 ns |     1.664 ns |   8,049 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     715.66 ns |     1.417 ns |     1.257 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     978.70 ns |     4.295 ns |     3.586 ns |  10,195 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,147.40 ns |    17.269 ns |    14.420 ns |   9,070 B |    2112 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     707.49 ns |     2.581 ns |     2.015 ns |   7,796 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     729.84 ns |     1.870 ns |     1.658 ns |   8,020 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     802.98 ns |     2.310 ns |     1.929 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,102.81 ns |     5.119 ns |     4.538 ns |  10,194 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,529.88 ns |    14.249 ns |    12.632 ns |   9,112 B |    2120 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   5,013.03 ns |    80.006 ns |    66.809 ns |   7,814 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,074.15 ns |    17.914 ns |    15.880 ns |   8,296 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,592.24 ns |    19.256 ns |    18.012 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   7,746.94 ns |    40.561 ns |    35.956 ns |  10,201 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  23,793.20 ns |   117.523 ns |   109.931 ns |   9,110 B |    9280 B |
|                                                   |              |               |              |              |           |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  79,500.16 ns |   240.492 ns |   200.822 ns |   7,804 B |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  81,018.90 ns |   304.949 ns |   285.249 ns |   8,295 B |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  91,728.54 ns |   297.631 ns |   232.371 ns |   9,006 B |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 123,703.41 ns |   387.419 ns |   362.392 ns |  10,195 B |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 408,176.45 ns | 1,874.517 ns | 1,661.710 ns |   9,133 B |  132174 B |