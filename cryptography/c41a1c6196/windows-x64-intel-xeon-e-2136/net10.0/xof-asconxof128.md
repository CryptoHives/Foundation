| Description                                       | TestDataSize | Mean        | Error    | StdDev   | Code Size | Allocated |
|-------------------------------------------------- |------------- |------------:|---------:|---------:|----------:|----------:|
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 128B         |    15.79 μs | 0.013 μs | 0.010 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 128B         |    18.93 μs | 0.033 μs | 0.031 μs |   4,989 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |    22.22 μs | 0.030 μs | 0.029 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 1KB          |    26.77 μs | 0.027 μs | 0.025 μs |   4,976 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |    73.54 μs | 0.082 μs | 0.073 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 8KB          |    89.09 μs | 0.124 μs | 0.116 μs |   4,902 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 128KB        |   952.75 μs | 0.944 μs | 0.883 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 128KB        | 1,143.07 μs | 1.594 μs | 1.491 μs |   4,921 B |         - |