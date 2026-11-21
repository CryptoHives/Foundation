| Description                    | Mean     | Error   | StdDev  | Allocated |
|------------------------------- |---------:|--------:|--------:|----------:|
| Unwrap · AES-KW (CryptoHives)  | 289.1 ns | 1.85 ns | 1.73 ns |      56 B |
| Unwrap · AES-KWP (CryptoHives) | 390.3 ns | 0.53 ns | 0.49 ns |      64 B |
| Unwrap · AES-KW (OS)           | 767.7 ns | 1.10 ns | 0.97 ns |      56 B |
| Unwrap · AES-KWP (OS)          | 807.0 ns | 1.74 ns | 1.54 ns |     136 B |
|                                |          |         |         |           |
| Wrap · AES-KW (CryptoHives)    | 308.8 ns | 0.56 ns | 0.50 ns |      64 B |
| Wrap · AES-KWP (CryptoHives)   | 383.4 ns | 0.43 ns | 0.34 ns |      72 B |
| Wrap · AES-KW (OS)             | 671.6 ns | 3.59 ns | 3.18 ns |      64 B |
| Wrap · AES-KWP (OS)            | 759.1 ns | 3.25 ns | 2.88 ns |     144 B |