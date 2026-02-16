| Description                            | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|--------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · XChaCha20-Poly1305 (SSSE3)   | 128B         |     750.3 ns |      4.51 ns |      4.22 ns |         - |
| Decrypt · XChaCha20-Poly1305 (Managed) | 128B         |   1,103.6 ns |     16.30 ns |     15.25 ns |         - |
|                                        |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (SSSE3)   | 128B         |     722.9 ns |     13.14 ns |     12.29 ns |         - |
| Encrypt · XChaCha20-Poly1305 (Managed) | 128B         |   1,055.1 ns |     20.83 ns |     22.29 ns |         - |
|                                        |              |              |              |              |           |
| Decrypt · XChaCha20-Poly1305 (SSSE3)   | 1KB          |   2,034.9 ns |     32.95 ns |     30.82 ns |         - |
| Decrypt · XChaCha20-Poly1305 (Managed) | 1KB          |   4,646.7 ns |     75.94 ns |     67.32 ns |         - |
|                                        |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (SSSE3)   | 1KB          |   1,968.2 ns |     12.25 ns |     10.23 ns |         - |
| Encrypt · XChaCha20-Poly1305 (Managed) | 1KB          |   4,565.4 ns |     23.20 ns |     20.57 ns |         - |
|                                        |              |              |              |              |           |
| Decrypt · XChaCha20-Poly1305 (SSSE3)   | 8KB          |  12,158.9 ns |    191.16 ns |    178.81 ns |         - |
| Decrypt · XChaCha20-Poly1305 (Managed) | 8KB          |  33,186.8 ns |    632.86 ns |    649.90 ns |         - |
|                                        |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (SSSE3)   | 8KB          |  12,183.3 ns |    232.71 ns |    217.68 ns |         - |
| Encrypt · XChaCha20-Poly1305 (Managed) | 8KB          |  33,106.2 ns |    619.28 ns |    579.27 ns |         - |
|                                        |              |              |              |              |           |
| Decrypt · XChaCha20-Poly1305 (SSSE3)   | 128KB        | 184,725.7 ns |  2,295.17 ns |  2,146.91 ns |         - |
| Decrypt · XChaCha20-Poly1305 (Managed) | 128KB        | 522,949.3 ns | 10,094.15 ns | 11,219.62 ns |         - |
|                                        |              |              |              |              |           |
| Encrypt · XChaCha20-Poly1305 (SSSE3)   | 128KB        | 184,695.1 ns |  2,326.31 ns |  2,062.22 ns |         - |
| Encrypt · XChaCha20-Poly1305 (Managed) | 128KB        | 521,993.4 ns | 10,192.72 ns | 10,906.09 ns |         - |