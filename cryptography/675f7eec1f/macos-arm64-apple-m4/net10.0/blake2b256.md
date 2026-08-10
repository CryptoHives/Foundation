| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      91.39 ns |     0.095 ns |     0.089 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      96.61 ns |     0.178 ns |     0.166 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     127.94 ns |     0.138 ns |     0.129 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     175.12 ns |     2.667 ns |     2.495 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     603.68 ns |     2.890 ns |     2.704 ns |    1120 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     169.92 ns |     0.342 ns |     0.320 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     187.59 ns |     0.511 ns |     0.453 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     233.94 ns |     0.237 ns |     0.222 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     360.41 ns |     1.747 ns |     1.634 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   1,121.13 ns |     2.624 ns |     2.454 ns |    1136 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     658.03 ns |     1.030 ns |     0.963 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     745.30 ns |     1.227 ns |     1.148 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     877.24 ns |     2.051 ns |     1.919 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   1,490.92 ns |     3.837 ns |     3.589 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   3,876.99 ns |    15.975 ns |    14.943 ns |    2016 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     738.39 ns |     2.132 ns |     1.994 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |     840.29 ns |     0.857 ns |     0.760 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     982.73 ns |     0.888 ns |     0.830 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   1,679.60 ns |     2.971 ns |     2.779 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   4,406.67 ns |    23.695 ns |    22.164 ns |    2024 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,199.84 ns |     9.819 ns |     9.185 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,950.98 ns |    11.263 ns |    10.535 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,841.35 ns |    14.991 ns |    14.022 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  12,039.40 ns |    12.650 ns |    11.833 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  30,028.21 ns |    81.326 ns |    76.073 ns |    9184 B |
|                                                   |              |               |              |              |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  83,034.55 ns |    86.539 ns |    80.948 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  95,268.38 ns |    71.123 ns |    66.529 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 109,143.85 ns |   181.706 ns |   169.968 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 193,346.45 ns |   503.834 ns |   471.286 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 484,066.68 ns | 1,189.809 ns | 1,112.948 ns |  132092 B |