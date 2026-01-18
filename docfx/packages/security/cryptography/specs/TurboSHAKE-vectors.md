# TurboSHAKE Test Vectors

Source: RFC 9861

## TurboSHAKE128

### Empty Message (M=empty, D=0x1F)
- **Output (32 bytes):** `1E 41 5F 1C 59 83 AF F2 16 92 17 27 7D 17 BB 53 8C D9 45 A3 97 DD EC 54 1F 1C E4 1A F2 C1 B7 4C`
- **Output (64 bytes):** `1E 41 5F 1C 59 83 AF F2 16 92 17 27 7D 17 BB 53 8C D9 45 A3 97 DD EC 54 1F 1C E4 1A F2 C1 B7 4C 3E 8C CA E2 A4 DA E5 6C 84 A0 4C 23 85 C0 3C 15 E8 19 3B DF 58 73 73 63 32 16 91 C0 54 62 C8 DF`

### Pattern Message (M=ptn(n), D=0x1F)

**Pattern:** `00 01 02 ... F9 FA` repeated.

| Message Length | Output (32 bytes) |
|----------------|-------------------|
| 1 byte       | `55 CE DD 6F 60 AF 7B B2 9A 40 42 AE 83 2E F3 F5 8D B7 29 9F 89 3E BB 92 47 24 7D 85 69 58 DA A9` |
| 17 bytes       | `9C 97 D0 36 A3 BA C8 19 DB 70 ED E0 CA 55 4E C6 E4 C2 A1 A4 FF BF D9 EC 26 9C A6 A1 11 16 12 33` |
| 17^2 bytes     | `96 C7 7C 27 9E 01 26 F7 FC 07 C9 B0 7F 5C DA E1 E0 BE 60 BD BE 10 62 00 40 E7 5D 72 23 A6 24 D2` |
| 17^3 bytes     | `D4 97 6E B5 6B CF 11 85 20 58 2B 70 9F 73 E1 D6 85 3E 00 1F DA F8 0E 1B 13 E0 D0 59 9D 5F B3 72` |

### Various Domain Separators (D)

| Message | D | Output (32 bytes) |
|---------|---|-------------------|
| `FF FF FF` | `01` | `BF 32 3F 94 04 94 E8 8E E1 C5 40 FE 66 0B E8 A0 C9 3F 43 D1 5E C0 06 99 84 62 FA 99 4E ED 5D AB` |
| `FF`       | `06` | `8E C9 C6 64 65 ED 0D 4A 6C 35 D1 35 06 71 8D 68 7A 25 CB 05 C7 4C CA 1E 42 50 1A BD 83 87 4A 67` |
| `FF FF FF` | `07` | `B6 58 57 60 01 CA D9 B1 E5 F3 99 A9 F7 77 23 BB A0 54 58 04 2D 68 20 6F 72 52 68 2D BA 36 63 ED` |

---

## TurboSHAKE256

### Empty Message (M=empty, D=0x1F)
- **Output (64 bytes):** `36 7A 32 9D AF EA 87 1C 78 02 EC 67 F9 05 AE 13 C5 76 95 DC 2C 66 63 C6 10 35 F5 9A 18 F8 E7 DB 11 ED C0 E1 2E 91 EA 60 EB 6B 32 DF 06 DD 7F 00 2F BA FA BB 6E 13 EC 1C C2 0D 99 55 47 60 0D B0`

### Pattern Message (M=ptn(n), D=0x1F)

| Message Length | Output (64 bytes) |
|----------------|-------------------|
| 1 byte       | `3E 17 12 F9 28 F8 EA F1 05 46 32 B2 AA 0A 24 6E D8 B0 C3 78 72 8F 60 BC 97 04 10 15 5C 28 82 0E 90 CC 90 D8 A3 00 6A A2 37 2C 5C 5E A1 76 B0 68 2B F2 2B AE 74 67 AC 94 F7 4D 43 D3 9B 04 82 E2` |
| 17 bytes       | `B3 BA B0 30 0E 6A 19 1F BE 61 37 93 98 35 92 35 78 79 4E A5 48 43 F5 01 10 90 FA 2F 37 80 A9 E5 CB 22 C5 9D 78 B4 0A 0F BF F9 E6 72 C0 FB E0 97 0B D2 C8 45 09 1C 60 44 D6 87 05 4D A5 D8 E9 C7` |
