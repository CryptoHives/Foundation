| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.722 μs | 0.0054 μs | 0.0048 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.409 μs | 0.0108 μs | 0.0096 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.196 μs | 0.0057 μs | 0.0050 μs |   6,967 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.941 μs | 0.0046 μs | 0.0043 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.908 μs | 0.0163 μs | 0.0136 μs |   3,011 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   6.062 μs | 0.0147 μs | 0.0123 μs |   6,994 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  12.399 μs | 0.0451 μs | 0.0400 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  15.306 μs | 0.0666 μs | 0.0591 μs |   3,011 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  19.039 μs | 0.0183 μs | 0.0153 μs |   6,994 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 160.265 μs | 0.6876 μs | 0.5742 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 197.531 μs | 0.9591 μs | 0.8502 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 245.644 μs | 0.4599 μs | 0.3591 μs |   6,994 B |         - |