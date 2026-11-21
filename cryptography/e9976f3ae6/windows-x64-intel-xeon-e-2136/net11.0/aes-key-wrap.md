| Description                    | Mean       | Error   | StdDev  | Code Size | Allocated |
|------------------------------- |-----------:|--------:|--------:|----------:|----------:|
| Unwrap · AES-KW (CryptoHives)  |   678.7 ns | 0.30 ns | 0.25 ns |   4,496 B |      56 B |
| Unwrap · AES-KWP (CryptoHives) |   860.1 ns | 0.47 ns | 0.44 ns |  11,945 B |      64 B |
| Unwrap · AES-KW (OS)           | 2,745.0 ns | 1.59 ns | 1.49 ns |  20,218 B |      56 B |
| Unwrap · AES-KWP (OS)          | 2,937.3 ns | 8.55 ns | 7.99 ns |  23,015 B |     152 B |
|                                |            |         |         |           |           |
| Wrap · AES-KW (CryptoHives)    |   681.4 ns | 0.37 ns | 0.31 ns |  11,178 B |      64 B |
| Wrap · AES-KWP (CryptoHives)   |   846.2 ns | 0.38 ns | 0.35 ns |  11,696 B |      72 B |
| Wrap · AES-KW (OS)             | 2,240.1 ns | 1.57 ns | 1.31 ns |  18,246 B |      64 B |
| Wrap · AES-KWP (OS)            | 2,746.5 ns | 1.85 ns | 1.64 ns |  26,402 B |     160 B |