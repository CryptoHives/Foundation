| Description                                       | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |      83.19 ns |     0.145 ns |   0.135 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |      94.77 ns |     0.278 ns |   0.232 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |     102.11 ns |     0.142 ns |   0.133 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |     128.64 ns |     0.473 ns |   0.442 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |     501.21 ns |     2.040 ns |   1.908 ns |    1216 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 137B         |     165.40 ns |     0.581 ns |   0.453 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 137B         |     177.46 ns |     0.312 ns |   0.260 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 137B         |     188.81 ns |     0.234 ns |   0.196 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 137B         |     251.70 ns |     0.494 ns |   0.462 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 137B         |     912.09 ns |     1.225 ns |   1.086 ns |    1232 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |     617.63 ns |     1.103 ns |   0.921 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |     642.58 ns |     1.838 ns |   1.535 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |     710.36 ns |     1.393 ns |   1.163 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |     975.68 ns |     1.857 ns |   1.646 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |   3,016.54 ns |     5.874 ns |   5.494 ns |    2112 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |     701.63 ns |     1.473 ns |   1.305 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |     730.00 ns |     0.831 ns |   0.649 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |     795.13 ns |     0.951 ns |   0.889 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |   1,097.94 ns |     2.042 ns |   1.910 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |   3,424.88 ns |     7.997 ns |   7.480 ns |    2120 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |   4,916.37 ns |    10.572 ns |   9.889 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |   5,011.30 ns |    20.282 ns |  16.937 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |   5,555.10 ns |    28.167 ns |  24.969 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |   7,693.36 ns |    12.223 ns |  10.207 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |  23,063.66 ns |    39.532 ns |  33.011 ns |    9280 B |
|                                                   |              |               |              |            |           |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |  78,622.44 ns |   468.224 ns | 415.069 ns |         - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |  79,957.61 ns |   166.103 ns | 138.704 ns |         - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |  88,458.92 ns |   226.296 ns | 211.677 ns |         - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        | 124,193.95 ns |   226.620 ns | 211.980 ns |         - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        | 391,159.01 ns | 1,020.559 ns | 954.631 ns |  132174 B |