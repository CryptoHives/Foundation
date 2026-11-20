| Description                    | Mean       | Error   | StdDev  | Code Size | Allocated |
|------------------------------- |-----------:|--------:|--------:|----------:|----------:|
| Unwrap · AES-KW (CryptoHives)  |   548.7 ns | 0.35 ns | 0.33 ns |  10,975 B |      56 B |
| Unwrap · AES-KWP (CryptoHives) |   638.3 ns | 0.23 ns | 0.18 ns |   5,366 B |      64 B |
| Unwrap · AES-KW (OS)           | 1,100.1 ns | 6.74 ns | 5.63 ns |  13,875 B |      56 B |
| Unwrap · AES-KWP (OS)          | 1,358.7 ns | 4.30 ns | 4.02 ns |  23,019 B |     152 B |
|                                |            |         |         |           |           |
| Wrap · AES-KW (CryptoHives)    |   503.0 ns | 0.16 ns | 0.14 ns |  11,352 B |      64 B |
| Wrap · AES-KWP (CryptoHives)   |   627.5 ns | 0.22 ns | 0.21 ns |  11,638 B |      72 B |
| Wrap · AES-KW (OS)             |   874.3 ns | 2.96 ns | 2.77 ns |  12,222 B |      64 B |
| Wrap · AES-KWP (OS)            | 1,271.5 ns | 8.12 ns | 6.78 ns |  26,389 B |     160 B |