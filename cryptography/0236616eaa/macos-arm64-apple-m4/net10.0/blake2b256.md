| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      96.52 ns |     0.024 ns |     0.021 ns |      96.52 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      99.62 ns |     0.369 ns |     0.346 ns |      99.65 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     136.48 ns |     2.648 ns |     4.568 ns |     138.37 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     179.24 ns |     1.314 ns |     1.230 ns |     178.92 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     733.84 ns |     6.313 ns |     5.906 ns |     733.99 ns |    1120 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     380.99 ns |     1.288 ns |     1.076 ns |     381.33 ns |         - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     795.30 ns |     0.416 ns |     0.369 ns |     795.15 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     902.45 ns |     1.723 ns |     1.527 ns |     902.70 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |   1,086.21 ns |     1.059 ns |     0.939 ns |   1,085.96 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   6,050.69 ns |     3.770 ns |     3.148 ns |   6,049.76 ns |    1136 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |   3,077.76 ns |     4.078 ns |     3.615 ns |   3,076.18 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |   3,496.04 ns |     2.367 ns |     1.977 ns |   3,495.28 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |   4,104.03 ns |    11.712 ns |    10.382 ns |   4,102.38 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   7,692.55 ns |     4.980 ns |     4.415 ns |   7,691.55 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |  21,017.75 ns |    14.555 ns |    12.154 ns |  21,014.96 ns |    2016 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |   3,459.81 ns |     1.713 ns |     1.519 ns |   3,459.24 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |   3,937.19 ns |     1.249 ns |     0.975 ns |   3,937.32 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |   4,597.64 ns |     2.928 ns |     2.445 ns |   4,598.08 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   8,667.99 ns |    17.738 ns |    14.812 ns |   8,662.21 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |  23,950.75 ns |    17.659 ns |    16.518 ns |  23,946.80 ns |    2024 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,166.21 ns |     1.205 ns |     1.127 ns |   5,165.99 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,876.38 ns |    16.765 ns |    15.682 ns |   5,873.64 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,798.57 ns |    14.642 ns |    11.431 ns |   6,795.69 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  13,124.98 ns |   221.534 ns |   481.598 ns |  12,944.70 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  34,015.75 ns |   633.335 ns |   592.422 ns |  33,679.37 ns |    9184 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  82,551.40 ns |    26.319 ns |    24.618 ns |  82,552.50 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  94,540.77 ns |    41.608 ns |    38.921 ns |  94,537.31 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 108,477.88 ns |    51.879 ns |    48.528 ns | 108,502.99 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 191,681.68 ns |   346.258 ns |   289.141 ns | 191,557.60 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 549,417.39 ns | 1,084.958 ns | 1,014.870 ns | 549,102.54 ns |  132092 B |