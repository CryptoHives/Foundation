| Description                                       | TestDataSize | Mean        | Error    | StdDev   | Code Size | Allocated |
|-------------------------------------------------- |------------- |------------:|---------:|---------:|----------:|----------:|
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 128B         |    15.78 μs | 0.005 μs | 0.004 μs |   6,601 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 128B         |    18.89 μs | 0.015 μs | 0.014 μs |  13,978 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |    22.19 μs | 0.008 μs | 0.007 μs |  12,936 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 1KB          |    26.65 μs | 0.010 μs | 0.009 μs |  13,978 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |    73.41 μs | 0.047 μs | 0.042 μs |   6,601 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 8KB          |    88.24 μs | 0.049 μs | 0.046 μs |  13,886 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 128KB        |   951.66 μs | 0.204 μs | 0.171 μs |   6,601 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 128KB        | 1,146.29 μs | 2.203 μs | 2.060 μs |  14,076 B |         - |