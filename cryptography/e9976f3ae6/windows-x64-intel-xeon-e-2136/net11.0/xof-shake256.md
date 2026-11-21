| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128B         |   6.601 μs | 0.0025 μs | 0.0021 μs |   9,561 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128B         |   8.876 μs | 0.0092 μs | 0.0086 μs |  16,289 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128B         |   9.170 μs | 0.0181 μs | 0.0169 μs |  11,749 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 1KB          |   9.399 μs | 0.0107 μs | 0.0090 μs |  15,896 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 1KB          |  12.680 μs | 0.0048 μs | 0.0040 μs |  16,121 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 1KB          |  13.019 μs | 0.0332 μs | 0.0311 μs |  10,690 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 8KB          |  30.362 μs | 0.0335 μs | 0.0313 μs |  16,086 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 8KB          |  41.624 μs | 0.0346 μs | 0.0324 μs |  16,119 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 8KB          |  42.195 μs | 0.1420 μs | 0.1259 μs |  11,749 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE256 · CryptoHives-Scalar | 128KB        | 385.953 μs | 0.1810 μs | 0.1604 μs |  16,086 B |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle       | 128KB        | 530.189 μs | 0.4194 μs | 0.3502 μs |  16,121 B |         - |
| AbsorbSqueeze · SHAKE256 · OS Native          | 128KB        | 539.172 μs | 2.0934 μs | 1.9582 μs |   4,181 B |         - |