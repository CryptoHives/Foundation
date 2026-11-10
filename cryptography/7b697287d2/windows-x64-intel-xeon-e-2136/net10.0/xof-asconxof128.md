| Description                                       | TestDataSize | Mean        | Error    | StdDev   | Code Size | Allocated |
|-------------------------------------------------- |------------- |------------:|---------:|---------:|----------:|----------:|
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 128B         |    15.81 μs | 0.015 μs | 0.014 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 128B         |    18.98 μs | 0.013 μs | 0.011 μs |   4,989 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |    22.22 μs | 0.010 μs | 0.009 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 1KB          |    26.75 μs | 0.016 μs | 0.014 μs |   4,989 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |    73.64 μs | 0.097 μs | 0.091 μs |   4,041 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 8KB          |    88.95 μs | 0.104 μs | 0.092 μs |   4,902 B |         - |
|                                                   |              |             |          |          |           |           |
| AbsorbSqueeze · Ascon-XOF128 · CryptoHives-Scalar | 128KB        |   953.87 μs | 0.655 μs | 0.613 μs |   4,025 B |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle       | 128KB        | 1,153.53 μs | 1.614 μs | 1.430 μs |   4,935 B |         - |