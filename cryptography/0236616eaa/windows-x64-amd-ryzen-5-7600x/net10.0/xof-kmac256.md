| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128B         |   3.702 μs | 0.0093 μs | 0.0083 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128B         |   4.675 μs | 0.0113 μs | 0.0095 μs |   9,971 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128B         |   5.986 μs | 0.0113 μs | 0.0101 μs |  15,807 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 1KB          |   5.076 μs | 0.0124 μs | 0.0104 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 1KB          |   6.343 μs | 0.0121 μs | 0.0101 μs |   9,372 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 1KB          |   8.099 μs | 0.0183 μs | 0.0162 μs |  17,039 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 8KB          |  15.478 μs | 0.0214 μs | 0.0179 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 8KB          |  19.158 μs | 0.0809 μs | 0.0717 μs |   9,359 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 8KB          |  24.207 μs | 0.0502 μs | 0.0445 μs |  15,820 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-256 · CryptoHives-Scalar | 128KB        | 193.940 μs | 0.4180 μs | 0.3491 μs |        NA |         - |
| AbsorbSqueeze · KMAC-256 · OS Native          | 128KB        | 237.456 μs | 0.4955 μs | 0.4392 μs |   9,991 B |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle       | 128KB        | 298.696 μs | 0.8647 μs | 0.7665 μs |  17,062 B |     128 B |