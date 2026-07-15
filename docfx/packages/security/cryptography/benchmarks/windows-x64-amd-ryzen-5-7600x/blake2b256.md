| Description                                       | TestDataSize | Mean          | Error      | StdDev     | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-----------:|-----------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |      84.77 ns |   0.556 ns |   0.464 ns |      84.68 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |      99.68 ns |   0.160 ns |   0.142 ns |      99.65 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      99.79 ns |   1.952 ns |   3.854 ns |      97.71 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |     130.65 ns |   0.274 ns |   0.243 ns |     130.62 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     506.73 ns |   8.602 ns |   7.626 ns |     503.83 ns |    1120 B |
|                                                   |              |               |            |            |               |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 137B         |     169.73 ns |   0.488 ns |   0.432 ns |     169.63 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     178.75 ns |   0.367 ns |   0.307 ns |     178.70 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     186.73 ns |   1.161 ns |   1.086 ns |     186.98 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     253.40 ns |   0.439 ns |   0.366 ns |     253.41 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |     924.71 ns |   2.262 ns |   2.116 ns |     924.25 ns |    1136 B |
|                                                   |              |               |            |            |               |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |     627.63 ns |   2.090 ns |   1.955 ns |     627.83 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     653.07 ns |   3.023 ns |   2.360 ns |     652.85 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     712.97 ns |   1.528 ns |   1.354 ns |     712.81 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     989.82 ns |   1.362 ns |   1.137 ns |     989.46 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,135.62 ns |   5.749 ns |   5.096 ns |   3,136.57 ns |    2016 B |
|                                                   |              |               |            |            |               |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |     711.94 ns |   2.601 ns |   2.433 ns |     711.92 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     731.78 ns |   2.604 ns |   2.436 ns |     731.47 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     801.81 ns |   2.337 ns |   1.825 ns |     802.11 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   1,118.78 ns |   1.984 ns |   1.856 ns |   1,117.97 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   3,545.12 ns |   8.523 ns |   7.556 ns |   3,545.16 ns |    2024 B |
|                                                   |              |               |            |            |               |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |   4,978.70 ns |  17.576 ns |  13.722 ns |   4,974.03 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,096.05 ns |   6.408 ns |   5.351 ns |   5,095.58 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   5,595.91 ns |  19.034 ns |  16.873 ns |   5,595.62 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   7,878.20 ns |  15.396 ns |  13.648 ns |   7,876.65 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  23,960.24 ns |  39.223 ns |  34.770 ns |  23,964.54 ns |    9184 B |
|                                                   |              |               |            |            |               |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |  79,777.96 ns | 262.069 ns | 245.140 ns |  79,780.97 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  80,974.38 ns | 131.960 ns | 110.193 ns |  80,968.88 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |  89,246.55 ns | 201.734 ns | 178.832 ns |  89,241.41 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        | 125,378.66 ns | 594.903 ns | 556.472 ns | 125,192.11 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 408,744.07 ns | 791.942 ns | 740.783 ns | 408,547.22 ns |  132078 B |