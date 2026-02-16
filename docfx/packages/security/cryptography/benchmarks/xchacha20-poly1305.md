| Description                            | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| Decrypt · XChaCha20-Poly1305 (Managed) | 128B         |     759.5 ns |    12.21 ns |  11.42 ns |         - |
|                                        |              |              |             |           |           |
| Encrypt · XChaCha20-Poly1305 (Managed) | 128B         |     718.6 ns |     3.68 ns |   3.44 ns |         - |
|                                        |              |              |             |           |           |
| Decrypt · XChaCha20-Poly1305 (Managed) | 1KB          |   2,024.4 ns |    11.36 ns |  10.07 ns |         - |
|                                        |              |              |             |           |           |
| Encrypt · XChaCha20-Poly1305 (Managed) | 1KB          |   1,987.6 ns |    13.00 ns |  12.16 ns |         - |
|                                        |              |              |             |           |           |
| Decrypt · XChaCha20-Poly1305 (Managed) | 8KB          |  12,148.9 ns |    42.64 ns |  37.80 ns |         - |
|                                        |              |              |             |           |           |
| Encrypt · XChaCha20-Poly1305 (Managed) | 8KB          |  12,171.7 ns |    71.44 ns |  66.82 ns |         - |
|                                        |              |              |             |           |           |
| Decrypt · XChaCha20-Poly1305 (Managed) | 128KB        | 186,648.0 ns | 1,036.75 ns | 969.77 ns |         - |
|                                        |              |              |             |           |           |
| Encrypt · XChaCha20-Poly1305 (Managed) | 128KB        | 186,350.2 ns | 1,015.82 ns | 950.20 ns |         - |